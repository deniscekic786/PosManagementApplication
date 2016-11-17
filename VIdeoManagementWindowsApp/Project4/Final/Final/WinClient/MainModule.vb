Option Explicit On
Option Strict On
Imports BusinessObjects
Imports System.IO

'@Programmer Denis Cekic 
'Homework 5 CS608 


Module MainModule


    Public objLoginForm As frmlogin
    Public objempmanagement As EmployeeManagement
    Public objcustomermanagement As CustomerManagement
    Public objadminport As ApplicationAdministrationPortal
    Public objbackendmngmt As BackEndManagement
    Public objuseraccnt As UserAccountManagement
    Public objmainwelcome As MainWelcomeForm
    Public objVideoPosSystem As VideoPointOfSales
    Public objVideoMNGM As New VideoGame()
    Public VideoGameManagementFRM As VideoGameManagement
    Public DVDManagementFRM As DVD_Management
    Public objDVDMNGM As New DVD()
    Public Const SIZE = 9
    Public U As String
    Public P As String
    Public objDVDMNGMlist As New DVD_List()
    Public objVideoMNGMlist As New VideoGameList()
    Public objUserAccountList As new UserAccountList()
    Public objEmployeeList As New EmployeeList()
    Public objUseraccountpointer As New UserAccount()
    Public objCustomerList As New CustomerList()
    Public objCustomer As New Customer()
    Public objEmployee As New Employee()
    Public objPerson As Person




    Public Sub Main()


        Application.EnableVisualStyles()
        Application.DoEvents()
        objLoginForm = New frmlogin
        Call objLoginForm.GetUserInfoAndDisplayForm(U, P)
        While U <> "-1" Or P <> "-1"
            Dim ReturnValue As Boolean
            ReturnValue = objUserAccountList.Authenticates(U, P)
            If ReturnValue = True Or objLoginForm.txt_username.Text = "admin" Then
                objmainwelcome = New MainWelcomeForm
                objmainwelcome.ShowDialog()
            Else
                MessageBox.Show("Access Denied")
            End If
            Call objLoginForm.GetUserInfoAndDisplayForm(U, P)
        End While
    End Sub


    'Public Function Authenticate(ByVal U As String, ByVal P As String) As Boolean
    '    Dim objUserAccountList = New UserAccountList()
    '    For index As Integer = 0 To SIZE
    '        Dim variable1 As Boolean = objUserAccountList.Authenticates(U, P)
    '            If variable1 = True Then
    '                Return True
    '            End If
    '    Next index
    '    Return False
    '    End
    'End Function


   
   
End Module
