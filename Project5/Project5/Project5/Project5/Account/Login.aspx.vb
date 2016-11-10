Imports BusinessObjects

Public Class NewLogin
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      


    End Sub

    Protected Sub TextBox1_TextChanged(sender As Object, e As EventArgs)

    End Sub

    Protected Sub login_btn_Click(sender As Object, e As EventArgs) Handles login_btn.Click
        Dim user As String
        Dim pw As String
        user = userName_txt.Text
        pw = passWord_txt.Text
        If String.IsNullOrEmpty(user) Or String.IsNullOrEmpty(pw)
            result_lbl.Text = "Wrong username or password. Please try again."
        End If
        Dim objUserAccountList As New UserAccountList
        Dim userExists As Boolean
        userExists = objUserAccountList.Authenticates(user,pw)
        If userExists = True
             Response.Redirect("~/Default.aspx")
            Else 
             result_lbl.Text = "Wrong username or password. Please try again."
        End If
    End Sub
End Class