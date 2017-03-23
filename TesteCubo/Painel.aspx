<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Painel.aspx.cs" Inherits="TesteCubo.Painel" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Corrida:
            <asp:Label runat="server" ID="lblCorrida"></asp:Label>
            <br /><br />
            Resultado Corrida
            <asp:GridView runat="server" ID="gridResultadoCorrida" AutoGenerateColumns="false">
                <Columns>
                    <asp:TemplateField HeaderText="Posição Chegada">
                        <ItemTemplate>
                            <%# Container.DataItemIndex + 1 %>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="nome" HeaderText="Nome" />
                    <asp:BoundField DataField="volta" HeaderText="Qtde Voltas Completadas" />
                    <asp:BoundField DataField="tempoTotal" HeaderText="Tempo Total de Prova" />
                </Columns>
            </asp:GridView>
            <br />
            Melhor Volta de cada piloto
            <asp:GridView runat="server" ID="gridMelhoresTempos" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="nome" HeaderText="Nome" />
                    <asp:BoundField DataField="tempo" HeaderText="Tempo" />
                </Columns>
            </asp:GridView>
            <br />
            Melhor Volta Corrida:
            <asp:Label runat="server" ID="lblMelhorVoltaCorrida"></asp:Label>
            <br />
            <br />
            Velocidade média de cada piloto durante toda corrida
            <asp:GridView runat="server" ID="gridVelocidadeMedia" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="nome" HeaderText="Nome" />
                    <asp:BoundField DataField="velocidadeMedia" HeaderText="Velocidade Média" DataFormatString="{0:N3}" />
                </Columns>
            </asp:GridView>
            <br />
            Tempo de chega após primeiro colocado
            <asp:GridView runat="server" ID="gridTempoAposPrimeiro" AutoGenerateColumns="false">
                <Columns>
                    <asp:BoundField DataField="nome" HeaderText="Nome" />
                    <asp:BoundField DataField="tempoChegada" HeaderText="Tempo" />
                </Columns>
            </asp:GridView>
        </div>
    </form>
</body>
</html>
