<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Lab4.aspx.cs" Inherits="Lab4.Lab4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Klausimai</title>
    <link rel="stylesheet" href="styles.css" runat="server" type="text/css"/>
</head>
<body>
    <form id="form1" runat="server">
        <asp:FileUpload ID="FileUpload1" runat="server" AllowMultiple="True" />
        <br />
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Nuskaityti" />
        <div class="none" id="div1" runat="server">
            <asp:Label ID="Label1" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Nera1" runat="server" Text="Tuščias sąrašas" CssClass="none"></asp:Label>
            <asp:Table ID="Table1" runat="server" GridLines="Both">
            </asp:Table>
            <asp:Label ID="Autoriai1" runat="server"></asp:Label>

        </div>
        <div class="none" id="div2" runat="server">
            <asp:Label ID="Label2" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Nera2" runat="server" Text="Tuščias sąrašas" CssClass="none"></asp:Label>
            <asp:Table ID="Table2" runat="server" GridLines="Both">
            </asp:Table>
                <asp:Label ID="Autoriai2" runat="server"></asp:Label>

        </div>
        <div class="none" id="div3" runat="server">
            <asp:Label ID="Label3" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Nera3" runat="server" Text="Tuščias sąrašas" CssClass="none"></asp:Label>
            <asp:Table ID="Table3" runat="server" GridLines="Both">
            </asp:Table>
                <asp:Label ID="Autoriai3" runat="server"></asp:Label>

        </div>

        <div class="none" id="div4" runat="server">
            <asp:Label ID="Label4" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Nera4" runat="server" Text="Tuščias sąrašas" CssClass="none"></asp:Label>
            <asp:Table ID="Table4" runat="server" GridLines="Both">
            </asp:Table>
                <asp:Label ID="Autoriai4" runat="server"></asp:Label>

        </div>

        <div class="none" id="div5" runat="server">
            <asp:Label ID="Label5" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Nera5" runat="server" Text="Tuščias sąrašas" CssClass="none"></asp:Label>
            <asp:Table ID="SortedTable1" runat="server" Width="29px" GridLines="Both">
            </asp:Table>
        </div>
        <div class="none" id="div6" runat="server">
            <asp:Label ID="Label6" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Nera6" runat="server" Text="Tuščias sąrašas" CssClass="none"></asp:Label>
            <asp:Table ID="SortedTable2" runat="server" GridLines="Both">
            </asp:Table>
        </div>
        <div class="none" id="div7" runat="server">
            <asp:Label ID="Label7" runat="server"></asp:Label>
            <br />
            <asp:Label ID="Nera7" runat="server" Text="Tuščias sąrašas" CssClass="none"></asp:Label>
            <asp:Table ID="FilteredTable" runat="server" GridLines="Both">
            </asp:Table>
        </div>
        <div class="none" id="div8" runat="server">
            <asp:Label ID="BestAuthors" runat="server"></asp:Label>
            <br />
            <asp:Label ID="BestMusicAuthors" runat="server"></asp:Label>
        </div>
        <asp:Label ID="error1" runat="server" ForeColor="Red"></asp:Label>
            <br />
            <asp:Label ID="error2" runat="server" ForeColor="Red"></asp:Label>

    </form>
</body>
</html>
