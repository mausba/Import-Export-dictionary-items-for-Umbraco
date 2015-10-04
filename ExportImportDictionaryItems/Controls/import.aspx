<%@ Page MasterPageFile="../../masterpages/umbracoDialog.Master" Language="C#" AutoEventWireup="true" CodeBehind="import.aspx.cs" Inherits="Inetdesign.ExportImportDictionaryItems.Controls.import" %>

<asp:Content ID="Content1" runat="server" ContentPlaceHolderID="body">
    <input id="tempFile" type="hidden" name="tempFile" runat="server" />

    <asp:Literal ID="FeedBackMessage" runat="server" />

    <table class="propertyPane" id="Table1" cellspacing="0" cellpadding="4" width="360" border="0" runat="server">
        <tr>
            <td class="propertyContent" colspan="2">
                <asp:Panel ID="Wizard" runat="server" Visible="True">
                    <p>
                        <span class="guiDialogNormal">
                            To import dictionary items, find the ".dic" file on your computer by clicking the "Browse" button and click "Import" (you'll be asked for confirmation on the next screen)
                        </span>
                        <br />
                        <br />
                        <asp:Literal ID="lblError" runat="server"></asp:Literal>
                    </p>

                    <p>
                        <input id="dicItemsFile" type="file" runat="server" allow=".dic" />
                    </p>


                    <asp:Button ID="submit" runat="server" OnClick="submit_Click"></asp:Button>
                    <em>or</em> <a href="#" onclick="UmbClientMgr.closeModalWindow(); return false;">cancel</a>
                </asp:Panel>


                <asp:Panel ID="Confirm" runat="server" Visible="False">
                    <asp:Literal ID="dtImportTo" runat="server"></asp:Literal>
                    <br />
                    <br />
                    <asp:Button ID="btnImport" runat="server" OnClick="import_Click"></asp:Button>
                </asp:Panel>
                <asp:Panel ID="done" runat="server" Visible="False">
                    Dictionary items have been imported!
                    <br />
                    <br />
                    <strong>Reload dictionary tree to see the imported items</strong>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Content>