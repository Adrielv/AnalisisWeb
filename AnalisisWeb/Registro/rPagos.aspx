﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="rPagos.aspx.cs" Inherits="AnalisisWeb.Registro.rPagos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br>
    <div class="form-row justify-content-center">
        <aside class="col-sm-8">
            <div class="card">
                <div class="card-header text-uppercase text-center text-info"> Registro Pagos</div>
                <article class="card-body">
                    <form>
                        <div class="col-md-12 col-md-offset-3">
                            <div class="container ">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" class="text-info text-center" Text="PagosId"></asp:Label>
                                    <asp:Button class="btn btn-info" CausesValidation ="False" ID="BuscarButton" runat="server" Text="Buscar" OnClick="buscarButton_Click" />
                                    <asp:TextBox class="form-control" type="number" ID="PagosIdTextBox" Text="0" runat="server" ValidationGroup="Guardar"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="AnalisisIdRequiredFieldValidator" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="PagosIdTextBox" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="AnalisisIdRegularExpressionValidator" runat="server" ErrorMessage="Solo Números" ControlToValidate="PagosIdTextBox" ValidationExpression="^[0-9]*$" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                </div>
                            </div>
                        </div>                      
                    
                         <div class="col-md-12 col-md-offset-3">
                            <div class="container ">
                                <div class="form-group">
                                     <asp:Label ID="Label10" runat="server" class="text-info" Text="FechaPago"></asp:Label>
                                    <asp:TextBox class="form-control" ID="FechaPagoTextBox" type="date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>                      
          
                       
                        <div class="form-group row">
                    <label for="Analisis" class="text-info col-md-2 col-form-label">Analisis</label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="AnalisisDropDown" CssClass="form-control input-sm"></asp:DropDownList>
                    </div>
                   
                      <label for="Cantidad" class="text-info col-sm-2 col-form-label">Monto</label>
                      <div class="col-sm-2">
                        <asp:TextBox ID="CantidadTextBox" runat="server" Class="form-control input-sm"></asp:TextBox>
                       
                      </div>
                      <div class="col-sm-1">
                        <asp:LinkButton runat="server" ID="AgregarGrid" CssClass="btn btn-info btn-md" Text="Agregar" OnClick="AgregarGrid_Click"></asp:LinkButton>
                    </div>
                 </div>

                      
                          <div class="row">
                        <asp:GridView ID="DetalleGridView" CssClass=" col-md-offset-4 col-sm-offset-4" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" Width="1831px" AutoGenerateColumns="true" >
                            <AlternatingRowStyle BackColor="White" />

                            <EditRowStyle BackColor="#2461BF" />
                            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#EFF3FB" />
                            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                            <SortedAscendingCellStyle BackColor="#F5F7FB" />
                            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
                            <SortedDescendingCellStyle BackColor="#E9EBEF" />
                            <SortedDescendingHeaderStyle BackColor="#4870BE" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        
     
                    <br>
                    
                        <div class="panel-footer">
                            <div class="text-center">
                                <div class="form-group" style="display: inline-block">
                                    <asp:Button Text="Nuevo" class="btn btn-primary" runat="server" ID="nuevoButton" OnClick="nuevoButton_Click" />
                                    <asp:Button Text="Guardar" class="btn btn-success" runat="server" ID="guadarButton" OnClick="guardarButton_Click" />
                                    <asp:Button Text="Eliminar" class="btn btn-danger" runat="server" ID="eliminarButton" OnClick="eliminarButton_Click" />
                                </div>
                            </div>
                        </div>

                    </form>
                </article>
            </div>
            <!-- card.// -->
    </div>
    <br>
</asp:Content>
