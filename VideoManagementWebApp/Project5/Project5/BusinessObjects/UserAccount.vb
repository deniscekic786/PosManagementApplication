Option Explicit On
Option Strict On
Imports System.IO
Imports System.Data                                     'Data Access (DataSet)
Imports System.Data.SqlClient                           'SQL Client Provider for Connecting to MS SQL Server Database
Imports System.Configuration                            'Configuration File for DB Connection

<Serializable()> _
Public Class UserAccount
    Inherits BusinessBase


    Private m_UserAccountId As Guid
    Private m_Username As String
    Private m_Password As String
    Private m_Email As String
    Private strConn As String = Me.GetDBConnectionString("WinClient.My.MySettings.SmallBusinessAppConnectionString")



    Public Property UserAccountID() As String
        Get
            Return m_UserAccountId.ToString
        End Get
        Set(ByVal value As String)
            m_UserAccountId = Guid.Parse(value)
            MyBase.MarkDirty()
        End Set
    End Property
    Public Property Username() As String
        Get
            Return m_Username
        End Get
        Set(ByVal value As String)
            m_Username = value
            MyBase.MarkDirty()
        End Set
    End Property
    Public Property Password() As String
        Get
            Return m_Password
        End Get
        Set(ByVal value As String)
            m_Password = value
            MyBase.MarkDirty()
        End Set
    End Property
    Public Property Email() As String
        Get
            Return m_Email
        End Get
        Set(ByVal value As String)
            m_Email = value
            MyBase.MarkDirty()
        End Set
    End Property
    Public Sub New()
        m_UserAccountId = Guid.NewGuid()
        m_Username = ""
        m_Password = ""
        m_Email = ""
        Person.Count = Person.Count + 1
    End Sub

    Public Sub New(ByVal User As String, ByVal Pass As String, ByVal Em As String)
        Me.m_UserAccountId = Guid.NewGuid()
        Me.Username = User
        Me.Password = Pass
        Me.Email = Em
        Person.Count = Person.Count + 1
    End Sub


    Public Event SecurityAlert(ByVal U As String, ByVal P As String)


    Public Function Authenticate(ByVal U As String, ByVal P As String) As Boolean
        RaiseEvent SecurityAlert(U, P)
        If m_Username = U And m_Password = P Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Shared Function CreateAccount(ByVal U As String, ByVal P As String, ByVal Email As String) As UserAccount

        Dim newuser As UserAccount
        newuser = New UserAccount(U, P, Email)

        Return newuser



    End Function
    Public Sub ChangeUsername(ByVal U As String)

        Me.Username = U



    End Sub
    Public Sub ChangePassword(ByVal P As String)
        Password = P
    End Sub

    Public Sub ChangeEmail(ByVal E As String)

        Email = E

    End Sub

    '*********************************************************************
    'Public interface to Create objects via OBJECT FACTORY METHOD
    Public Shared Function Create() As UserAccount
        'Calls internal DataPortal_Create method to do the work
        Return DataPortal_Create()
    End Function

    Public Sub Load(ByVal Key As String)
        'Calls Local DatPortal_Fetch(Key) To do the work
        DataPortal_Fetch(Key)

    End Sub

    Public Sub Save()
        'Only If Marked for deletion & Old then delete record, otherwise do nothing
        If Me.IsDeleted And Not Me.IsNew Then
            'Calls Local DataPortal_Delete(Key) to execute query
            DataPortal_Delete(Me.UserAccountID)

        Else
            'Only if dirty, Update or Insert, otherwise do nothing
            If Me.IsDirty Then
                If Me.IsNew Then
                    'We are new so insert new record in database
                    'Calls Local DataPortal_Insert() to execute query
                    DataPortal_Insert()
                Else
                    'We are OLD so updated record in database
                    'Calls Local DataPortal_Update() to execute query
                    DataPortal_Update()
                End If
            End If

        End If

    End Sub

    '*********************************************************************
    'Support for immediate delete
    Public Sub ImmediateDelete(ByVal Key As String)
        'Calls Local DatPortal_Delete() To do the work
        DataPortal_Delete(Key)
    End Sub
    '*********************************************************************
    'Protected Data Access Methods declarations

    'Data Access Code for Creating a New Business Object
    Protected Shared Function DataPortal_Create() As UserAccount
        'Create object and assign default values from database etc.

        'ADD DATA ACCESS CODE HERE USING ADO.NET

        Return Nothing
    End Function

    'Data Access Code to fetch an object from Database
    Protected Sub DataPortal_Fetch(ByVal Key As String)
        Dim objConn As New SqlConnection(strConn)
        Try
            objConn.Open()
            Dim strSQL As String = "usp_Selectuser"
            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("@ACID", SqlDbType.VarChar).Value = Key
            Dim objDR As SqlDataReader = objCmd.ExecuteReader
            If objDR.HasRows Then
                objDR.Read()
                Me.UserAccountID = CStr(objDR.Item(0))
                Me.Username = CStr(objDR.Item(1))
                Me.Password = CStr(objDR.Item(2))
                Me.Email = CStr(objDR.Item(3))
            Else
                Throw New System.ApplicationException("Load Error! Record Not Found")
            End If
            objDR.Close()
            objDR = Nothing
            objCmd.Dispose()
            objCmd = Nothing
        Catch objBOEx As NotSupportedException
            Throw New System.NotSupportedException(objBOEx.Message)
        Catch objA As ApplicationException
            Throw New System.ApplicationException(objA.Message)
        Catch objEx As Exception
            Throw New System.Exception("Load Error: " & objEx.Message)
        Finally
            objConn.Close()
            objConn.Dispose()
            objConn = Nothing
        End Try
        'At the end, set New flag to False. NOT Dirty since found in database
        MyBase.MarkOld()
    End Sub

    'Data Access Code to Update an Objects data to database
    Protected Sub DataPortal_Update()
        Dim objConn As New SqlConnection(strConn)
        Try
            objConn.Open()
            Dim strSQL As String
            strSQL = "usp_Updateuser"

            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Me.Username
            objCmd.Parameters.Add("@PW", SqlDbType.VarChar).Value = Me.Password
            objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Me.Email
            objCmd.Parameters.Add("@ACID", SqlDbType.VarChar).Value = Me.UserAccountID
            Dim intRecordsAffected As Integer = objCmd.ExecuteNonQuery()
            If intRecordsAffected <> 1 Then
                Throw New System.ApplicationException("UPDATE Query Failed")
            End If
            objCmd.Dispose()
            objCmd = Nothing
        Catch objBOEx As NotSupportedException
            Throw New System.NotSupportedException(objBOEx.Message)
        Catch objA As ApplicationException
            Throw New System.ApplicationException(objA.Message)
        Catch objEx As Exception
            Throw New System.Exception("Update Error: " & objEx.Message)
        Finally
            objConn.Close()
            objConn.Dispose()
            objConn = Nothing
        End Try
        'At the end, set New flag to False. NOT Dirty since found in database
        MyBase.MarkOld()
    End Sub

    'Data Access Code to insert a new object to database
    Protected Sub DataPortal_Insert()
        Dim objConn As New SqlConnection(strConn)
        Try
            objConn.Open()
            Dim strSQL As String
            strSQL = "usp_InsertUser"

            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("@ACID", SqlDbType.VarChar).Value = Me.UserAccountID
            objCmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = Me.Username
            objCmd.Parameters.Add("@PW", SqlDbType.VarChar).Value = Me.Password
            objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Me.Email


            Dim intRecordsAffected As Integer = objCmd.ExecuteNonQuery()
            If intRecordsAffected <> 1 Then
                Throw New System.ApplicationException("INSERT Query Failed")
            End If
            objCmd.Dispose()
            objCmd = Nothing
        Catch objBOEx As NotSupportedException
            Throw New System.NotSupportedException(objBOEx.Message)
        Catch objA As ApplicationException
            Throw New System.ApplicationException(objA.Message)
        Catch objEx As Exception
            Throw New System.Exception("Insert Error: " & objEx.Message)
        Finally
            objConn.Close()
            objConn.Dispose()
            objConn = Nothing
        End Try
        'At the end, set New flag to False. NOT Dirty since found in database
        MyBase.MarkOld()


    End Sub
    'Data Access Code to immediatly delete an object from database.
    Protected Sub DataPortal_Delete(ByVal Key As String)
        Dim objConn As New SqlConnection(strConn)
        Try
            objConn.Open()
            Dim strSQL As String = "usp_DeleteUser"
            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("@ACID", SqlDbType.VarChar).Value = Key
            Dim intRecordsAffected As Integer = objCmd.ExecuteNonQuery()
            If intRecordsAffected <> 1 Then
                Throw New System.ApplicationException("Delete Query Failed")
            End If
            objCmd.Dispose()
            objCmd = Nothing
        Catch objBOEx As NotSupportedException
            Throw New System.NotSupportedException(objBOEx.Message)
        Catch objA As ApplicationException
            Throw New System.ApplicationException(objA.Message)
        Catch objEx As Exception
            Throw New System.Exception("Delete Error: " & objEx.Message)
        Finally
            objConn.Close()
            objConn.Dispose()
            objConn = Nothing
        End Try
        'At the end, set New flag to False. NOT Dirty since found in database
        MyBase.MarkNew()
    End Sub
    '*********************************************************************
    'Methods used to assist other methods or maintenance

    '*********************************************************************
    'Method will return the Database Connection string from a Configuration File
    'Method takes as parameter a key or ID of the location of the connection string
    'To return.
    Protected Function GetDBConnectionString(ByVal Key As String) As String
        Dim objConnSetting As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(Key)
        Return objConnSetting.ConnectionString
    End Function













End Class