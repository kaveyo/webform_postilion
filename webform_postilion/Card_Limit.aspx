<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Card_Limit.aspx.cs" Inherits="webform_postilion.Card_Limit" %>


<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
  
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/4.7.0/css/font-awesome.min.css">
    <script>
        <link href="Content/css/util.css" rel="stylesheet" /> 
    </script>
      <h3>CARD LIMITS</h3>
        <hr />
    <div class="container card shadow d-flex justify-content-center mt-5" >
        <div class="row">
            <div class="col-xs-12">

                <ul class="nav nav-tabs nav-pills nav-justified">
                    <li class="active">
                        <a href="#homeTab" data-toggle="tab">Daily Limit</a>
                    </li>
                    <li >
                        <a href="#contactTab" data-toggle="tab">Weekly Limit</a>
                    </li>
                    
                </ul>
                <div class="tab-content">
                    <div id="homeTab" class="tab-pane active">
                        <h4 class="text-info">DAILY LIMITS</h4>
        <hr />
            <div class="row">

             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">NUMBER OF PURCHASE</label>
                    <asp:TextBox ID="NUMBER_OF_PURCHASE" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="NUMBER OF PURCHASE"></asp:TextBox>                                       
               <asp:RequiredFieldValidator ID="RequiredFieldValidator21" runat="server" ErrorMessage="RequiredField" ControlToValidate="NUMBER_OF_PURCHASE" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator13" runat="server" ControlToValidate="NUMBER_OF_PURCHASE" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Number of Cash Withdrawals</label>
                    <asp:TextBox ID="Number_of_Cash_Withdrawals" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Number of Cash Withdrawals"></asp:TextBox>                                       
          <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="RequiredField" ControlToValidate="Number_of_Cash_Withdrawals" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator14" runat="server" ControlToValidate="Number_of_Cash_Withdrawals" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
                
             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Number of Payments</label>
                    <asp:TextBox ID="Number_of_Payments" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Number of Payments"></asp:TextBox>                                       
         <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="RequiredField" ControlToValidate="Number_of_Payments" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator15" runat="server" ControlToValidate="Number_of_Payments" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
                </div>


                 <hr />
              <h4 class="text-info">Overall Transaction Amounts</h4>
        <hr />
             <div class="row">

             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Purchase Amount</label>
                    <asp:TextBox ID="Purchase_Amount" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Purchase Amount"></asp:TextBox>                                       
           <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ErrorMessage="RequiredField" ControlToValidate="Purchase_Amount" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator16" runat="server" ControlToValidate="Purchase_Amount" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
             </div>
             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Cash Amount</label>
                    <asp:TextBox ID="Cash_Amount" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Cash Amount"></asp:TextBox>                                       
          <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ErrorMessage="RequiredField" ControlToValidate="Cash_Amount" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator17" runat="server" ControlToValidate="Cash_Amount" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
                
             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Payment Amount</label>
                    <asp:TextBox ID="Payment_Amount" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Payment Amount"></asp:TextBox>                                       
           <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ErrorMessage="RequiredField" ControlToValidate="Payment_Amount" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator18" runat="server" ControlToValidate="Payment_Amount" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
             </div>
                </div>
                
             <div class="row">

             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Card Not Present Amount</label>
                    <asp:TextBox ID="Card_Not_Present_Amount" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Card Not Present Amount"></asp:TextBox>                                       
          <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ErrorMessage="RequiredField" ControlToValidate="Card_Not_Present_Amount" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator19" runat="server" ControlToValidate="Card_Not_Present_Amount" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Deposit Amount Available</label>
                    <asp:TextBox ID="Deposit_Amount_Available" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Deposit Amount Available"></asp:TextBox>                                       
          <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ErrorMessage="RequiredField" ControlToValidate="Deposit_Amount_Available" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator20" runat="server" ControlToValidate="Deposit_Amount_Available" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>               
             
                </div>

               <hr />
              <h4 class="text-info">Offline Transaction Amounts</h4>
        <hr />
              <div class="row">

             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Purchase Amount</label>
                    <asp:TextBox ID="Purchase_Amount_off" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Purchase Amount"></asp:TextBox>                                       
         <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ErrorMessage="RequiredField" ControlToValidate="Purchase_Amount_off" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator21" runat="server" ControlToValidate="Purchase_Amount_off" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Cash Amount </label>
                    <asp:TextBox ID="Cash_Amount_off" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Cash Amount"></asp:TextBox>                                       
         <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ErrorMessage="RequiredField" ControlToValidate="Cash_Amount_off" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator22" runat="server" ControlToValidate="Cash_Amount_off" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>               
             
                </div>
                  <div class="row">

             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Payment Amount </label>
                    <asp:TextBox ID="Payment_Amount_off" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Payment Amount"></asp:TextBox>                                       
         <asp:RequiredFieldValidator ID="RequiredFieldValidator10" runat="server" ErrorMessage="RequiredField" ControlToValidate="Payment_Amount_off" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator23" runat="server" ControlToValidate="Payment_Amount_off" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Card Not Present Amount</label>
                    <asp:TextBox ID="Card_Not_Present_Amount_off" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Card Not Present Amount"></asp:TextBox>                                       
         <asp:RequiredFieldValidator ID="RequiredFieldValidator11" runat="server" ErrorMessage="RequiredField" ControlToValidate="Card_Not_Present_Amount_off" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator24" runat="server" ControlToValidate="Card_Not_Present_Amount_off" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>               
             
                </div>

                         <div class="container">
            <div class="">
           
             
            </div>
        </div>
                    </div>

             
                    <div id="contactTab" class="tab-pane">
                          <h4 class="text-info">WEEKLY LIMITS</h4>
        <hr />
            <div class="row">

             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">NUMBER OF PURCHASE</label>
                    <asp:TextBox ID="TextBox1" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="NUMBER OF PURCHASE"></asp:TextBox>                                       
          <asp:RequiredFieldValidator ID="RequiredFieldValidator12" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox1" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator4" runat="server" ControlToValidate="TextBox1" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Number of Cash Withdrawals</label>
                    <asp:TextBox ID="TextBox2" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Number of Cash Withdrawals"></asp:TextBox>                                       
          <asp:RequiredFieldValidator ID="RequiredFieldValidator13" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox2" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ControlToValidate="TextBox2" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
                
             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Number of Payments</label>
                    <asp:TextBox ID="TextBox3" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Number of Payments"></asp:TextBox>                                       
         <asp:RequiredFieldValidator ID="RequiredFieldValidator14" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox3" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator2" runat="server" ControlToValidate="TextBox3" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
                </div>

                 <hr />
              <h4 class="text-info">Overall Transaction Amounts</h4>
             <hr />
             <div class="row">

             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Purchase Amount</label>
                    <asp:TextBox ID="TextBox4" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Purchase Amount"></asp:TextBox>                                       
         <asp:RequiredFieldValidator ID="RequiredFieldValidator15" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox4" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator3" runat="server" ControlToValidate="TextBox4" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Cash Amount</label>
                    <asp:TextBox ID="TextBox5" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Cash Amount"></asp:TextBox>                                       
          <asp:RequiredFieldValidator ID="RequiredFieldValidator16" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox5" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator5" runat="server" ControlToValidate="TextBox5" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
                
             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Payment Amount</label>
                    <asp:TextBox ID="TextBox6" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Payment Amount"></asp:TextBox>                                       
          <asp:RequiredFieldValidator ID="RequiredFieldValidator17" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox6" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator6" runat="server" ControlToValidate="TextBox6" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
                </div>
                
             <div class="row">

             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Card Not Present Amount</label>
                    <asp:TextBox ID="TextBox7" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Card Not Present Amount"></asp:TextBox>                                       
          <asp:RequiredFieldValidator ID="RequiredFieldValidator18" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox7" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator7" runat="server" ControlToValidate="TextBox7" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Deposit Amount Available</label>
                    <asp:TextBox ID="TextBox8" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Deposit Amount Available"></asp:TextBox>                                       
         <asp:RequiredFieldValidator ID="RequiredFieldValidator19" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox8" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator8" runat="server" ControlToValidate="TextBox8" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>               
             
                </div>

               <hr />
              <h4 class="text-info">Offline Transaction Amounts</h4>
        <hr />
              <div class="row">

             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Purchase Amount</label>
                    <asp:TextBox ID="TextBox9" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Purchase Amount"></asp:TextBox>                                       
          <asp:RequiredFieldValidator ID="RequiredFieldValidator20" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox9" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator9" runat="server" ControlToValidate="TextBox9" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Cash Amount </label>
                    <asp:TextBox ID="TextBox10" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Cash Amount"></asp:TextBox>                                       
          <asp:RequiredFieldValidator ID="RequiredFieldValidator22" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox10" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator10" runat="server" ControlToValidate="TextBox10" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>               
             
                </div>
                  <div class="row">

             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Payment Amount </label>
                    <asp:TextBox ID="TextBox11" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Payment Amount"></asp:TextBox>                                       
          <asp:RequiredFieldValidator ID="RequiredFieldValidator23" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox11" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator11" runat="server" ControlToValidate="TextBox11" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>
             <div class="form-group col-md-4">
                    <label for="exampleInputEmail1">Card Not Present Amount</label>
                    <asp:TextBox ID="TextBox12" runat="server" class="form-control" aria-describedby="emailHelp" placeholder="Card Not Present Amount"></asp:TextBox>                                       
          <asp:RequiredFieldValidator ID="RequiredFieldValidator24" runat="server" ErrorMessage="RequiredField" ControlToValidate="TextBox12" ForeColor="Red"></asp:RequiredFieldValidator>
             <asp:RegularExpressionValidator ID="RegularExpressionValidator12" runat="server" ControlToValidate="TextBox12" ErrorMessage="Please Enter Only Numbers" ForeColor="Red" ValidationExpression="^\d+$"></asp:RegularExpressionValidator>
                
                 </div>               
             
                </div>
                         <div class="container">
            <div class="">
           
              <%-- <asp:Button ID="Button1" runat="server" Text="SAVE" class="btn btn-success"  OnClick="Button5_Click"/>
               <div class="btn btn-danger" ><a href='Account_Card_Result.aspx' style="color: #FFFFFF"> BACK</a></div>  --%>
           
            </div>
        </div>
                    </div>
                    
                    
                </div>
                  <asp:Button ID="Button4" runat="server" Text="SAVE" class="btn btn-success" OnClick="Button4_Click" />
                  <asp:Button ID="Button1" runat="server" Text="LOCK CARD" class="btn btn-info" OnClick="Button5_Click" />
               <div class="btn btn-danger" ><a href='Search_Account_Pan.aspx' style="color: #FFFFFF"> BACK</a></div>  
           
            </div>
        </div>
    </div>

    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js">
    </script>
    <script src="bootstrap/js/bootstrap.min.js"></script>
    
  
</asp:Content>
