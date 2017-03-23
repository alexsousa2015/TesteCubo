using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using TesteCubo.Entidades;

namespace TesteCubo
{
    public partial class Painel : System.Web.UI.Page
    {
        Corrida corrida;

        protected void Page_Load(object sender, EventArgs e)
        {
            LerArquivo();
            CarregarResultados();
        }

        private void LerArquivo()
        {
            bool primeiraLinha = true;
            Volta volta;
            string linha;

            using (StreamReader arquivo = new StreamReader(@"c:\\temp\\corrida.txt"))
            {
                corrida = new Corrida() { nome = "TesteCubo" };
                while ((linha = arquivo.ReadLine()) != null)
                {
                    if (!primeiraLinha)
                    {
                        volta = new Volta();
                        var valoresLinha = linha.Split('\t');
                        valoresLinha = valoresLinha.Where(r => !r.Trim().Equals("")).ToArray();
                        volta.hora = TimeSpan.Parse(valoresLinha[0].Trim());
                        volta.numero = Convert.ToInt16(valoresLinha[2].Trim());
                        volta.tempo = TimeSpan.Parse("00:" + valoresLinha[3].Trim());
                        volta.velocidadeMedia = Convert.ToDouble(valoresLinha[4].Trim());
                        volta.piloto = new Piloto() { nome = valoresLinha[1].Trim() };
                        corrida.listaVoltas.Add(volta);
                    }
                    else
                        primeiraLinha = false;
                }

                arquivo.Close();
            }
        }

        private void CarregarResultados()
        {
            lblCorrida.Text = corrida.nome;

            var resultadoCorrida = corrida.listaVoltas.GroupBy(r => r.piloto.nome).Select(r => new { nome = r.Key, hora = r.Max(z => z.hora), volta = r.Max(z => z.numero), tempoTotal = string.Format("{0:mm\\:ss\\.fff}", new TimeSpan(r.Sum(z => z.tempo.Ticks))) }).OrderByDescending(r => r.volta).OrderBy(r => r.hora);
            gridResultadoCorrida.DataSource = resultadoCorrida;
            gridResultadoCorrida.DataBind();

            var menorTempoCorrida = corrida.listaVoltas.OrderBy(r => r.tempo).First();
            lblMelhorVoltaCorrida.Text = menorTempoCorrida.piloto.nome + " " + string.Format("{0:mm\\:ss\\.fff}", menorTempoCorrida.tempo);

            var menorTempoPiloto = corrida.listaVoltas.GroupBy(r => r.piloto.nome).Select(r => new { nome = r.Key, tempo = string.Format("{0:mm\\:ss\\.fff}", r.Min(z => z.tempo)) }).OrderBy(r => r.tempo);
            gridMelhoresTempos.DataSource = menorTempoPiloto;
            gridMelhoresTempos.DataBind();

            var velocidadeMediaCorrida = corrida.listaVoltas.GroupBy(r => r.piloto.nome).Select(r => new { nome = r.Key, velocidadeMedia = r.Sum(z => z.velocidadeMedia) / r.Max(z => z.numero) }).OrderByDescending(r => r.velocidadeMedia);
            gridVelocidadeMedia.DataSource = velocidadeMediaCorrida;
            gridVelocidadeMedia.DataBind();

            corrida.listaVoltas = corrida.listaVoltas.Where(r => r.numero.Equals(4)).OrderBy(r => r.hora).ToList();
            var primeiro = corrida.listaVoltas.First();
            corrida.listaVoltas.Remove(primeiro);
            var tempoAposPrimeiro = corrida.listaVoltas.Select(r => new { nome = r.piloto.nome, tempoChegada = string.Format("{0:mm\\:ss\\.fff}", primeiro.hora - r.hora) });
            gridTempoAposPrimeiro.DataSource = tempoAposPrimeiro;
            gridTempoAposPrimeiro.DataBind();
        }
    }
}