<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ShopProfile.ascx.cs" Inherits="Cuyahoga.Modules.Shop.ShopProfile" %>
<%@ Register TagPrefix="cc1" Namespace="Cuyahoga.ServerControls" Assembly="Cuyahoga.ServerControls" %>
<asp:placeholder id="phShopTop" runat="server"></asp:placeholder>
<asp:DataList ID="DataListAddress" runat="server" OnDeleteCommand="DataListAddress_DeleteCommand" OnEditCommand="DataListAddress_EditCommand" OnUpdateCommand="DataListAddress_UpdateCommand" OnCancelCommand="DataListAddress_CancelCommand">
      <HeaderTemplate>

    </HeaderTemplate>
      <ItemTemplate>
          <table width="100%">
              <tr class="shoprow">
                  <td class="shopcolumn">
                      <asp:HiddenField ID="HiddenFieldId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AddressId")%>' />
                      <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandName="Edit"></asp:LinkButton></td>
                  <td class="shopcolumn">
                      <asp:Label ID="LabelFirstname" runat="server"></asp:Label></td>
                  <td  class="shopcolumn">
                      <asp:Label ID="LabelFirstnameValue" runat="server"><%# DataBinder.Eval(Container.DataItem, "Firstname")%></asp:Label></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                      <asp:LinkButton ID="LinkButtonDelete" runat="server" CommandName="Delete"></asp:LinkButton></td>
                  <td class="shopcolumn">
                      <asp:Label ID="LabelLastname" runat="server"></asp:Label></td>
                  <td  class="shopcolumn">
                      <asp:Label ID="LabelLastnameValue" runat="server"><%# DataBinder.Eval(Container.DataItem, "Lastname")%></asp:Label></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelAddress1" runat="server" Width="104px"></asp:Label></td>
                  <td  class="shopcolumn">
                      <asp:Label ID="LabelAddress1Value" runat="server"><%# DataBinder.Eval(Container.DataItem, "Address1")%></asp:Label></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn" style="height: 21px">
                  </td>
                  <td class="shopcolumn" style="height: 21px" >
                      <asp:Label ID="LabelAddress2" runat="server"></asp:Label></td>
                  <td  class="shopcolumn" style="height: 21px">
                      <asp:Label ID="LabelAddress2Value" runat="server"><%# DataBinder.Eval(Container.DataItem, "Address2")%></asp:Label></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelZip" runat="server"></asp:Label></td>
                  <td  class="shopcolumn">
                      <asp:Label ID="LabelZipValue" runat="server"><%# DataBinder.Eval(Container.DataItem, "Zip")%></asp:Label></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelRegion" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelRegionValue" runat="server"><%# DataBinder.Eval(Container.DataItem, "Region")%></asp:Label></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelCity" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelCityValue" runat="server"><%# DataBinder.Eval(Container.DataItem, "City")%></asp:Label></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelCountry" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelCountryValue" runat="server"><%# DataBinder.Eval(Container.DataItem, "Country")%></asp:Label>
                  </td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelTelephone1" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelTelephone1Value" runat="server"><%# DataBinder.Eval(Container.DataItem, "Telephone1")%></asp:Label></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelTelephone2" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelTelephone2Value" runat="server"><%# DataBinder.Eval(Container.DataItem, "Telephone2")%></asp:Label></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td  class="shopcolumn">
                      <asp:Label ID="LabelMobile" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelMobileValue" runat="server"><%# DataBinder.Eval(Container.DataItem, "Mobile")%></asp:Label></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelDelivery" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelDeliveryValue" runat="server"><%# GetDeliveryText(DataBinder.Eval(Container.DataItem, "Delivery"))%></asp:Label></td>
              </tr>
          </table>
    </ItemTemplate>
    <AlternatingItemTemplate>
          <table width="100%">
              <tr class="shoprowalt">
                  <td class="shopcolumn">
                        <asp:HiddenField ID="HiddenFieldId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AddressId")%>' />
                        <asp:LinkButton ID="LinkButtonEdit" runat="server" CommandName="Edit"></asp:LinkButton></td>
                  <td class="shopcolumn">
                      <asp:Label ID="LabelFirstname" runat="server"></asp:Label></td>
                  <td  class="shopcolumn">
                      <asp:Label ID="LabelFirstnameValue" runat="server"><%# DataBinder.Eval(Container.DataItem, "Firstname")%></asp:Label></td>
              </tr>
              <tr class="shoprowalt">
                  <td class="shopcolumn">
                      <asp:LinkButton ID="LinkButtonDelete" runat="server" CommandName="Delete"></asp:LinkButton></td>
                  <td class="shopcolumn">
                      <asp:Label ID="LabelLastname" runat="server"></asp:Label></td>
                  <td  class="shopcolumn">
                      <asp:Label ID="LabelLastnameValue" runat="server"><%# DataBinder.Eval(Container.DataItem, "Lastname")%></asp:Label></td>
              </tr>
              <tr class="shoprowalt">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelAddress1" runat="server" Width="104px"></asp:Label></td>
                  <td  class="shopcolumn">
                      <asp:Label ID="LabelAddress1Value" runat="server"><%# DataBinder.Eval(Container.DataItem, "Address1")%></asp:Label></td>
              </tr>
              <tr class="shoprowalt">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelAddress2" runat="server"></asp:Label></td>
                  <td  class="shopcolumn">
                      <asp:Label ID="LabelAddress2Value" runat="server"><%# DataBinder.Eval(Container.DataItem, "Address2")%></asp:Label></td>
              </tr>
              <tr class="shoprowalt">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelZip" runat="server"></asp:Label></td>
                  <td  class="shopcolumn">
                      <asp:Label ID="LabelZipValue" runat="server"><%# DataBinder.Eval(Container.DataItem, "Zip")%></asp:Label></td>
              </tr>
              <tr class="shoprowalt">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelRegion" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelRegionValue" runat="server"><%# DataBinder.Eval(Container.DataItem, "Region")%></asp:Label></td>
              </tr>
              <tr class="shoprowalt">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelCity" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelCityValue" runat="server"><%# DataBinder.Eval(Container.DataItem, "City")%></asp:Label></td>
              </tr>
              <tr class="shoprowalt">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelCountry" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelCountryValue" runat="server"><%# DataBinder.Eval(Container.DataItem, "Country")%></asp:Label>
                  </td>
              </tr>
              <tr class="shoprowalt">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelTelephone1" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelTelephone1Value" runat="server"><%# DataBinder.Eval(Container.DataItem, "Telephone1")%></asp:Label></td>
              </tr>
              <tr class="shoprowalt">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelTelephone2" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelTelephone2Value" runat="server"><%# DataBinder.Eval(Container.DataItem, "Telephone2")%></asp:Label></td>
              </tr>
              <tr class="shoprowalt">
                  <td class="shopcolumn">
                  </td>
                  <td  class="shopcolumn">
                      <asp:Label ID="LabelMobile" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelMobileValue" runat="server"><%# DataBinder.Eval(Container.DataItem, "Mobile")%></asp:Label></td>
              </tr>
              <tr class="shoprowalt">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelDelivery" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelDeliveryValue" runat="server"><%# GetDeliveryText(DataBinder.Eval(Container.DataItem, "Delivery"))%></asp:Label></td>
              </tr>
          </table>    
    </AlternatingItemTemplate>
    <EditItemTemplate>
          <table width="100%">
              <tr class="shoprow">
                  <td class="shopcolumn">
                       <asp:HiddenField ID="HiddenFieldId" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "AddressId")%>' />
                        <asp:LinkButton ID="LinkButtonSave" runat="server" CommandName="Update"></asp:LinkButton></td>
                  <td class="shopcolumn">
                      <asp:Label ID="LabelFirstname" runat="server"></asp:Label></td>
                  <td  class="shopcolumn">
                      <asp:TextBox ID="TextBoxFirstnameValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Firstname")%>'/></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                      <asp:LinkButton ID="LinkButtonCancel" runat="server" CommandName="Cancel"></asp:LinkButton></td>
                  <td class="shopcolumn">
                      <asp:Label ID="LabelLastname" runat="server"></asp:Label></td>
                  <td  class="shopcolumn">
                      <asp:TextBox ID="TextBoxLastnameValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Lastname")%>'/></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelAddress1" runat="server" Width="104px"></asp:Label></td>
                  <td  class="shopcolumn">
                      <asp:TextBox ID="TextBoxAddress1Value" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address1")%>'/></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelAddress2" runat="server"></asp:Label></td>
                  <td  class="shopcolumn">
                      <asp:TextBox ID="TextBoxAddress2Value" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Address2")%>'/></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelZip" runat="server"></asp:Label></td>
                  <td  class="shopcolumn">
                      <asp:TextBox ID="TextBoxZipValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Zip")%>'/></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelRegion" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:TextBox ID="TextBoxRegionValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Region")%>'/></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelCity" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:TextBox ID="TextBoxCityValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "City")%>'/></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelCountry" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:TextBox ID="TextBoxCountryValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Country")%>'/>
                  </td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelTelephone1" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:TextBox ID="TextBoxTelephone1Value" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Telephone1")%>'/></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelTelephone2" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:TextBox ID="TextBoxTelephone2Value" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Telephone2")%>'/></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td  class="shopcolumn">
                      <asp:Label ID="LabelMobile" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:TextBox ID="TextBoxMobileValue" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Mobile")%>'/></td>
              </tr>
              <tr class="shoprow">
                  <td class="shopcolumn">
                  </td>
                  <td class="shopcolumn" >
                      <asp:Label ID="LabelDelivery" runat="server"></asp:Label></td>
                  <td class="shopcolumn" >
                      <asp:CheckBox ID="CheckBoxDeliveryValue" runat="server" Checked='<%# GetDelivery(DataBinder.Eval(Container.DataItem, "Delivery"))%>' /></td>
              </tr>
          </table>
    </EditItemTemplate>
</asp:DataList><br />
&nbsp;<asp:Button ID="ButtonAddNewAddress" runat="server" OnClick="ButtonAddNewAddress_Click" /><br />
<br />
&nbsp;<asp:placeholder id="phShopFooter" runat="server"></asp:placeholder>