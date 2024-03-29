﻿<%@ Page Title="" Language="C#" MasterPageFile="~/MainMaster.Master" AutoEventWireup="true" CodeBehind="rAnalisis.aspx.cs" Inherits="AnalisisWeb.Registro.rAnalisis" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <br>
    <div class="form-row justify-content-center">
        <aside class="col-sm-8">
            <div class="card">
                <div class="card-header text-uppercase text-center text-info"> Registro Analisis</div>
                <article class="card-body">
                    <form>
                        <div class="col-md-12 col-md-offset-3">
                            <div class="container ">
                                <div class="form-group">
                                    <asp:Label ID="Label1" runat="server" class="text-info text-center" Text="AnalisisId"></asp:Label>
                                    <asp:Button class="btn btn-info" CausesValidation ="False" ID="BuscarButton" runat="server" Text="Buscar" OnClick="buscarButton_Click" />
                                    <asp:TextBox class="form-control" type="number" ID="AnalisisIdTextBox" Text="0" runat="server" ValidationGroup="Guardar"></asp:TextBox>
                                   <asp:RequiredFieldValidator ID="AnalisisIdRequiredFieldValidator" runat="server" ErrorMessage="No puede estar vacío" ControlToValidate="analisisIdTextBox" Display="Dynamic" ForeColor="Red">*</asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="AnalisisIdRegularExpressionValidator" runat="server" ErrorMessage="Solo Números" ControlToValidate="analisisIdTextBox" ValidationExpression="^[0-9]*$" ValidationGroup="Guardar"></asp:RegularExpressionValidator>
                                </div>
                            
                        </div>                      
                    
                         <div class="col-md-12 col-md-offset-3">
                            <div class="container ">
                                <div class="form-group">
                                     <asp:Label ID="Label10" runat="server" class="text-info" Text="Fecha"></asp:Label>
                                    <asp:TextBox class="form-control" ID="FechaTextBox" type="date" runat="server"></asp:TextBox>
                                </div>
                            </div>
                        </div>                      
                        <br>
                          
                <div class="form-group row">
                    <label for="Paciente" class="col-md-2 col-form-label">Paciente</label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="PacienteDropDown" CssClass="form-control input-sm"></asp:DropDownList>                 
                    </div>
                </div>
                       
                        <div class="form-group row">
                    <label for="TiposAnalisis" class="col-md-2 col-form-label">Tipo</label>
                    <div class="col-md-4">
                        <asp:DropDownList runat="server" ID="TiposAnalisisDropDown" CssClass="form-control input-sm"></asp:DropDownList>
                    </div>
                    <div class="col-xs-2">
                        <asp:LinkButton runat="server" ID="TiposModal" CausesValidation="false" CssClass="btn btn-outline-success btn-md" data-toggle="modal" data-target="#rTiposAnalisis" Text="+"></asp:LinkButton>
                    </div>
                      <label for="Resultado" class="col-sm-2 col-form-label">Resultado</label>
                      <div class="col-sm-2">
                        <asp:TextBox ID="ResultadoTextBox" runat="server" Class="form-control input-sm"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="RFVResultado" runat="server" ValidationGroup="Analisis" MaxLength="200" ControlToValidate="ResultadoTextBox" ErrorMessage="Campo obligatorio" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio"></asp:RequiredFieldValidator>
                      </div>
                      <div class="col-sm-1">
                        <asp:LinkButton runat="server" ID="AgregarGrid" ValidationGroup="Analisis" CssClass="btn btn-outline-info btn-md" Text="Agregar" OnClick="AgregarGrid_Click"></asp:LinkButton>
                    </div>
                 </div>

                      
                       <asp:GridView ID="DetalleGridView" class="col-md-3 col-md-offset-3" runat="server"  AllowPaging="true" PageSize="10" ShowHeaderWhenEmpty="false" AutoGenerateDeleteButton="true" CellPadding="4" ForeColor="#333333" GridLines="None" Width="767px" AutoGenerateColumns="True"   >
                   
                    
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
        
     
            <div class="modal fade" id="rTiposAnalisis" tabindex="-1" role="dialog" aria-labelledby="exampleModalCenterTitle" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
            <div class="modal-content">
            <div class="modal-header" style="background-color:#5d748a">
                <h5 class="modal-title" id="exampleModalLongTitle" style="color:#fff">Tipos de Analisis</h5>
            </div>

           
            <div class="modal-body">
             <div class="container-fluid">
                 <div class="form-group row">
                 <label for="TiposId" class="col-sm-2 col-form-label">ID</label>
                 <div class="col-md-3 col-sm-2 col-xs-4">
                   <asp:TextBox type="number" ID="TipoIdTextBox" runat="server" min=0 class="form-control input-sm"></asp:TextBox>
                 </div>
                 <div class="col-md-3 col-sm-2 col-xs-4">
                 <asp:LinkButton ID="TiposBuscarButton" CssClass="btn btn-info btn-block btn-md" CausesValidation="false" runat="server" Text="Buscar" OnClick="TipoBuscarButton_Click"></asp:LinkButton>
                 </div> 
                 </div>
                 <div class="form-group row">
                   <label for="Analisis" class="col-sm-2 col-form-label">Analisis</label>
                   <div class="col-md-6">
                    <asp:TextBox ID="AnalisisTextBox" runat="server" Class="form-control input-sm"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RFVAnalisis" runat="server" ValidationGroup="Tipos" MaxLength="200" ControlToValidate="AnalisisTextBox" ErrorMessage="Campo obligatorio" ForeColor="Black" Display="Dynamic" SetFocusOnError="True" ToolTip="Campo obligatorio"></asp:RequiredFieldValidator>
                   </div>
                 </div>
                  
             </div>
            </div>

            <div class="modal-footer">
                
            <asp:Button Text="Nuevo" class="btn btn-primary" style="color:#FFF" runat="server" CausesValidation="false" id="TiposNuevoButton" OnClick="TipoNuevoButton_Click" />
            <asp:Button Text="Guardar" class="btn btn-success" runat="server" ValidationGroup="Tipos" id="TiposGuardarButton" OnClick="TipoGuardarButton_Click" />
            <asp:Button Text="Eliminar" class="btn btn-danger" runat="server" CausesValidation="false" id="TiposEliminarButton" OnClick="TipoEliminarButton_Click" />
            </div>
                  
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
    </div>
                    </form>
                </article>
            </div>
            <!-- card.// -->
    </div>
    <br>
</asp:Content>
