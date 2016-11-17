Option Explicit On
Option Strict On
Imports System.IO                                       'File/IO
Imports System.Data                                     'Data Access (DataSet)
Imports System.Data.SqlClient                               'OLEDB Provider for Connecting to MS Access Database
Imports System.Configuration                            'Configuration File for DB Connection

<Serializable()> _
Public Class Customer
    Inherits Person

    Private m_IDNumber As String
    Private m_Email As String
    Private strConn As String = Me.GetDBConnectionString("WinClient.My.MySettings.SmallBusinessAppConnectionString")


    Public Property IDNumber() As String
        Get
            Return m_IDNumber
        End Get
        Set(ByVal value As String)
            If Len(Trim(value)) = 0 Then
                Throw New NotSupportedException("Business Rule: ID cannot be blank")
            End If
            If Not Me.IsNew Then
                Throw New NotSupportedException("Business Rule: ID is Write-once only")
            End If
            If (Len(Trim(value)) <> 4) Then
                Throw New NotSupportedException("ID Value not exact Lenght")
            End If
            m_IDNumber = value
            MyBase.MarkDirty()
        End Set
    End Property

    Public Shadows Property Email() As String
        Get
            Return m_Email
        End Get
        Set(ByVal value As String)
            If Len(Trim(value)) = 0 Then
                Throw New NotSupportedException("Business Rule: ID cannot be blank")
            End If
            m_Email = value
            MyBase.MarkDirty()
        End Set
    End Property
    Public Sub New()
        m_IDNumber = ""
        m_Email = ""
        Person.Count = Person.Count + 1
    End Sub
    Public Sub New(ByVal IDNumber As String, ByVal FirstName As String, ByVal LastName As String, ByVal SSNumber As String, ByVal Birthdate As String, ByVal Address As String, ByVal PhoneNumber As String, ByVal Email As String)

        Me.SSNumber = SSNumber
        Me.FirstName = FirstName
        Me.LastName = LastName
        Me.Birthdate = CDate(Birthdate)
        Me.Address = Address
        Me.PhoneNumber = PhoneNumber

        Me.IDNumber = IDNumber
        Me.Email = Email

        Person.Count = Person.Count + 1


    End Sub

    Public Overrides Sub print()

        Try
            Dim objwrite As New StreamWriter("Network_Printer.txt", True)
            Dim name As String = FirstName & "," & LastName
            objwrite.WriteLine("Customer Information = ")
            objwrite.WriteLine("ID number....." & IDNumber)
            objwrite.WriteLine("Full Name....." & FirstName & "," & LastName)
            objwrite.WriteLine("Social Security number....." & SSNumber)
            objwrite.WriteLine("Birthdate....." & Birthdate)
            objwrite.WriteLine("Age....." & Age)
            objwrite.WriteLine("Address....." & Address)
            objwrite.WriteLine("Phone Number....." & PhoneNumber)
            objwrite.WriteLine("Email....." & Email)
            objwrite.WriteLine(".....................................................................")
            objwrite.Close()
        Catch objE As Exception
            Throw New System.Exception("Print Method Error: " & objE.Message)
        End Try
    End Sub
    '*********************************************************************
    'Public interface to Create objects via OBJECT FACTORY METHOD
    Public Shared Function Create() As Customer
        'Calls internal DataPortal_Create method to do the work
        Return DataPortal_Create()
    End Function
    '*********************************************************************
    Public Sub Load(ByVal Key As String)
        'Calls Local DatPortal_Fetch(Key) To do the work
        DataPortal_Fetch(Key)

    End Sub

    Public Sub Save()
        'Only If Marked for deletion & Old then delete record, otherwise do nothing
        If Me.IsDeleted And Not Me.IsNew Then
            'Calls Local DataPortal_Delete(Key) to execute query
            DataPortal_Delete(Me.IDNumber)

        Else

            If Me.IsDirty Then
                If Me.IsNew Then
                    DataPortal_Insert()
                Else
                    DataPortal_Update()
                End If
            End If

        End If

    End Sub

    'Support for immediate delete
    Public Sub ImmediateDelete(ByVal Key As String)
        'Calls Local DatPortal_Delete() To do the work
        DataPortal_Delete(Key)
    End Sub
    '*********************************************************************
    'Protected Data Access Methods declarations

    'Data Access Code for Creating a New Business Object
    Protected Shared Function DataPortal_Create() As Customer
        'Create object and assign default values from database etc.

        'ADD DATA ACCESS CODE HERE USING ADO.NET

        Return Nothing
    End Function

    'Data Access Code to fetch an object from Database
    Protected Sub DataPortal_Fetch(ByVal Key As String)
        Dim objConn As New SqlConnection(strConn)
        Try
            objConn.Open()
            Dim strSQL As String = "usp_SelectCustomer"

            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("@Customer_ID", SqlDbType.VarChar).Value = Key
            Dim objDR As SqlDataReader = objCmd.ExecuteReader
            If objDR.HasRows Then
                objDR.Read()
                Me.IDNumber = CStr(objDR.Item(0))
                Me.FirstName = CStr(objDR.Item(1))
                Me.LastName = CStr(objDR.Item(2))
                Me.SSNumber = CStr(objDR.Item(3))
                Me.Birthdate = CDate(objDR.Item(4))
                Me.Address = CStr(objDR.Item(5))
                Me.PhoneNumber = CStr(objDR.Item(6))
                Me.Email = CStr(objDR.Item(7))
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
            strSQL = "usp_UpdateCustomers"

            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("@First_Name", SqlDbType.VarChar).Value = Me.FirstName
            objCmd.Parameters.Add("@Last_Name", SqlDbType.VarChar).Value = Me.LastName
            objCmd.Parameters.Add("@Birthdate", SqlDbType.Date).Value = Me.Birthdate
            objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Me.Address
            objCmd.Parameters.Add("@Phone_Number", SqlDbType.VarChar).Value = Me.PhoneNumber
            objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Me.Email
            objCmd.Parameters.Add("@Customer_ID", SqlDbType.VarChar).Value = Me.IDNumber


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
            strSQL = "usp_InsertCustomer"

            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("@Customer_ID", SqlDbType.VarChar).Value = Me.IDNumber
            objCmd.Parameters.Add("@First_Name", SqlDbType.VarChar).Value = Me.FirstName
            objCmd.Parameters.Add("@Last_Name", SqlDbType.VarChar).Value = Me.LastName
            objCmd.Parameters.Add("@SSN", SqlDbType.VarChar).Value = Me.SSNumber
            objCmd.Parameters.Add("@Birthdate", SqlDbType.Date).Value = Me.Birthdate
            objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Me.Address
            objCmd.Parameters.Add("@Phone_Number", SqlDbType.VarChar).Value = Me.PhoneNumber
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
            Dim strSQL As String = "usp_DeleteCustomers"
            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.Parameters.Add("@Customer_ID", SqlDbType.VarChar).Value = Key
            objCmd.CommandType = CommandType.StoredProcedure
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
            Throw New System.Exception("Load Error: " & objEx.Message)
        Finally
            objConn.Close()
            objConn.Dispose()
            objConn = Nothing
        End Try
        'At the end, set New flag to False. NOT Dirty since found in database
        MyBase.MarkNew()

    End Sub


    Public Sub DataPortal_InsertTester()
        Dim objConn As New SqlConnection(strConn)

        Try
            objConn.Open()
            Dim strSQL As String
            strSQL = "INSERT INTO UserAccount ( Users_AccountID, Users_AccountName," _
              & "Users_AccountPassword, Users_AccountEmail)" _
              & "VALUES (?, ?, ?, ?)"




            Dim objCmd As New SqlCommand(strSQL, objConn)

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
