<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication2.WebForm1" ClientIDMode="Static" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #btnStart {
            color: #2A4F5E;
            font-family: Verdana;
            font-size: 18px;
            width: 200px;
        }

        #btnStart:hover {
                cursor: pointer;
            }

        .checkersBoardCell {
            font-family: Verdana;
            font-size: 18px;
            color: white;
            text-align: center;
            vertical-align: central;
            text-decoration: none;
        }

        .lblPlayerOneNameTop {
            font-family: Verdana;
            font-size: 14px;
            color: blueviolet;
        }

        .lblPlayerTwoNameTop {
            font-family: Verdana;
            font-size: 14px;
            color: darkcyan;
        }

        .lblPlayerBottom {
            font-family: Verdana;
            font-size: 14px;
        }

        .txtPlayerBottom {
            font-family: Verdana;
            font-size: 14px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <asp:UpdatePanel ID="pnlMain" runat="server">
                <ContentTemplate>
                    <asp:Table runat="server" ID="tblHeader">
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="4" Width="100px" Height="30px">
                                <asp:Label ID="lblPlayerOne" runat="server" CssClass="lblPlayerOneNameTop"></asp:Label>
                            </asp:TableCell>
                            <asp:TableCell ColumnSpan="4" Width="100px" Height="30px">
                                <asp:Label ID="lblPlayerTwo" runat="server" CssClass="lblPlayerTwoNameTop"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                    <asp:UpdatePanel runat="server" ID="pnlBody" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Table runat="server" ID="tblBody">
                            </asp:Table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <asp:Table runat="server" ID="tblFooter">
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblPlayerOneNameBottom" Text="Player One: " runat="server" CssClass="lblPlayerBottom"></asp:Label>
                                <asp:TextBox ID="txtPlayerOneName" runat="server" CssClass="txtPlayerBottom"></asp:TextBox>
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:Label ID="lblPlayerTwoNameBottom" Text="Player Two: " runat="server" CssClass="lblPlayerBottom"></asp:Label>
                                <asp:TextBox ID="txtPlayerTwoName" runat="server" CssClass="txtPlayerBottom"></asp:TextBox>
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell ColumnSpan="4" HorizontalAlign="Right" Height="50px">
                                <asp:Button runat="server" ID="btnStart" Text="Start" OnClick="btnStart_Click" />
                            </asp:TableCell>
                        </asp:TableRow>
                        <asp:TableRow>
                            <asp:TableCell>
                                <asp:Label ID="lblError" runat="server"></asp:Label>
                            </asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </ContentTemplate>
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="btnStart" EventName="Click" />
                </Triggers>
            </asp:UpdatePanel>
        </div>
    </form>
</body>
</html>
