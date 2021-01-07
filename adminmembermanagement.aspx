<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="adminmembermanagement.aspx.cs" Inherits="ElibraryManagement.adminmembermanagement" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <script type="text/javascript">
        $(document).ready(function () {
            alert("Hello! I am an alert 2");
            $(".table").prepend($("<thead></thead>").append($(this).find("tr:first"))).dataTable();
            alert("Hello! I am an alert 3");
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container-fluid">
        <div class="row">
            <div class="col-md-5">
                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member Details</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <img width="100px" src="imgs/generaluser.png" />
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>

                         <div class="row">
                             <div class="col-md-3">
                                <label>Member ID</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control" placeholder="Member ID"></asp:TextBox>
                                    <asp:Button ID="Button1" class="btn btn-primary" runat="server" Text="Go" OnClick="Button1_Click" />
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Full Name</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control" placeholder="Full Name" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-5">
                                <label>Account Status</label>
                                <div class="form-group">
                                <div class="input-group">
                                    <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control mr-1" placeholder="Status"></asp:TextBox>
                                    <asp:LinkButton ID="LinkButton1"  class="btn btn-success mr-1" runat="server" OnClick="LinkButton1_Click">
                                        <i class="fas fa-check-circle"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton2"  class="btn btn-warning mr-1" runat="server" OnClick="LinkButton2_Click">
                                        <i class="far fa-pause-circle"></i>
                                    </asp:LinkButton>
                                    <asp:LinkButton ID="LinkButton3"  class="btn btn-danger mr-1" runat="server" OnClick="LinkButton3_Click">
                                        <i class="fas fa-times-circle"></i>
                                    </asp:LinkButton>
                                    
                                    </div>                                
                                </div>
                            </div>
                             
                             </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>DOB</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox3" runat="server" CssClass="form-control" placeholder="DOB" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <label>Contact No</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="TextBox4" runat="server" CssClass="form-control" placeholder="Contact No" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Email ID</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control" placeholder="Email ID" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                             </div>

                        <div class="row">
                            <div class="col-md-4">
                                <label>State</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control" placeholder="State" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                             <div class="col-md-4">
                                <label>City</label>
                                <div class="form-group">
                                    <div class="input-group">
                                    <asp:TextBox ID="TextBox10" runat="server" CssClass="form-control" placeholder="City" ReadOnly="True"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-4">
                                <label>Pincode</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox11" runat="server" CssClass="form-control" placeholder="Pincode" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                             </div>

                        <div class="row">
                            <div class="col-md-12">
                                <label>Full Postal Address</label>
                                <div class="form-group">
                                    <asp:TextBox ID="TextBox5" runat="server" CssClass="form-control" placeholder="Full Postal Address" TextMode="MultiLine" Rows="2" ReadOnly="True"></asp:TextBox>
                                </div>
                            </div>
                             
                         </div>

                             <div class="row">
                                 <div class="col-8 mx-auto">
                                <asp:Button ID="Button3" class="btn btn-danger btn-lg btn-block" runat="server" Text="Delete User Permanently" OnClick="Button3_Click" />
                                </div>
                                 <
                             </div>
                        



                 
    </div>

    </div>

                <a href="homepage.aspx"><< Back to Home</a><br /><br />

        </div>

            <div class="col-md-7">

                <div class="card">
                    <div class="card-body">
                        
                        <div class="row">
                            <div class="col">
                                <center>
                                    <h4>Member List</h4>
                                </center>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col">
                                <center>
                                    <hr />
                                </center>
                            </div>
                        </div>

                        <div class="row">
                            <div class="col">
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:elibraryDBConnectionString %>" SelectCommand="SELECT * FROM [member_master_tbl]"></asp:SqlDataSource>
                                <asp:GridView class="table table-striped table-bordered" ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="member_id" DataSourceID="SqlDataSource1">
                                    <Columns>
                                        <asp:BoundField DataField="member_id" HeaderText="ID" ReadOnly="True" SortExpression="member_id" />
                                        <asp:BoundField DataField="full_name" HeaderText="Name" SortExpression="full_name" />
                                        <asp:BoundField DataField="account_status" HeaderText="Account Status" SortExpression="account_status" />
                                        <asp:BoundField DataField="contact_no" HeaderText="Contact No" SortExpression="contact_no" />
                                        <asp:BoundField DataField="email" HeaderText="Email" SortExpression="email" />
                                        <asp:BoundField DataField="state" HeaderText="State" SortExpression="state" />
                                        <asp:BoundField DataField="city" HeaderText="City" SortExpression="city" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                        </div>

                        
    </div>

    </div>

            </div>

    </div>

    </div>
</asp:Content>
