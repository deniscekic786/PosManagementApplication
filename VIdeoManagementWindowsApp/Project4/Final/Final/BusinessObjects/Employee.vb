Option Explicit On
Option Strict On
Imports System.IO
Imports System.Data                                     'Data Access (DataSet)
Imports System.Data.SqlClient                           'SQL Client Provider for Connecting to MS SQL Server Database
Imports System.Configuration                            'Configuration File for DB Connection

<Serializable()> _
Public Class Employee
    Inherits Person



    Private m_Email As String
    Private m_JobTitle As String
     Private strConn As String = Me.GetDBConnectionString("WinClient.My.MySettings.SmallBusinessAppConnectionString")

    Public Property Email() As String
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

    Public Property JobTitle() As String
        Get
            Return m_JobTitle
        End Get
        Set(ByVal value As String)
            If Len(Trim(value)) = 0 Then
                Throw New NotSupportedException("Business Rule: ID cannot be blank")
            End If
            m_JobTitle = value
            MyBase.MarkDirty()
        End Set
    End Property


    Public Sub New()


        m_Email = ""
        m_JobTitle = ""
        Person.Count = Person.Count + 1

    End Sub

    Public Sub New(ByVal ssn As String, ByVal FN As String, ByVal LN As String, ByVal BD As Date, ByVal ADD As String, ByVal PN As String, ByVal EM As String, ByVal JT As String)

        Me.SSNumber = ssn
        Me.FirstName = FN
        Me.LastName = LN
        Me.Birthdate = BD
        Me.Address = ADD
        Me.PhoneNumber = PN
        Me.Email = EM
        Me.JobTitle = JT

        Person.Count = Person.Count + 1


    End Sub
    Public Overrides Sub print()


        Try
            If Not File.Exists("Network_Printer.txt") Then
                File.Create("Network_Printer.txt")
                Dim objFile As New StreamWriter("Network_Printer.txt")
                objFile.Close()
            End If
            Dim objWrite As New StreamWriter("Network_Printer.txt", True)

            objWrite.WriteLine("Employee:")
            objWrite.WriteLine("Social Security number....." & SSNumber)
            objWrite.WriteLine("Full Name....." & FirstName & "," & LastName)
            objWrite.WriteLine("Birthdate....." & Birthdate)
            objWrite.WriteLine("Age....." & Age)
            objWrite.WriteLine("Address....." & Address)
            objWrite.WriteLine("Phone Number....." & PhoneNumber)
            objWrite.WriteLine("Email....." & Email)
            objWrite.WriteLine("Job Title....." & JobTitle)
            objWrite.WriteLine(".....................................................................")
            objWrite.Close()
        Catch objE As Exception
            Throw New System.Exception("print all Method Error: " & objE.Message)
        End Try
    End Sub

    '*********************************************************************
    'Public interface to Create objects via OBJECT FACTORY METHOD
    Public Shared Function Create() As Employee
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
            DataPortal_Delete(Me.SSNumber)

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
    Protected Shared Function DataPortal_Create() As Employee
        'Create object and assign default values from database etc.

        'ADD DATA ACCESS CODE HERE USING ADO.NET

        Return Nothing
    End Function

    'Data Access Code to fetch an object from Database
    Protected Sub DataPortal_Fetch(ByVal Key As String)
        Dim objConn As New SqlConnection(strConn)
        Try
            objConn.Open()
            Dim strSQL As String = "usp_SelectEmployee"

            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("@SSN", SqlDbType.VarChar).Value = Key
            Dim objDR As SqlDataReader = objCmd.ExecuteReader
            If objDR.HasRows Then
                objDR.Read()
                Me.SSNumber = CStr(objDR.Item(0))
                Me.FirstName = CStr(objDR.Item(1))
                Me.LastName = CStr(objDR.Item(2))
                Me.Birthdate = CDate(objDR.Item(3))
                Me.Address = CStr(objDR.Item(4))
                Me.PhoneNumber = CStr(objDR.Item(5))
                Me.Email = CStr(objDR.Item(6))
                Me.JobTitle = CStr(objDR.Item(7))
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
            strSQL = "usp_UpdateEmployees"
       

            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("@First_Name", SqlDbType.VarChar).Value = Me.FirstName
            objCmd.Parameters.Add("@Last_Name", SqlDbType.VarChar).Value = Me.LastName
            objCmd.Parameters.Add("@Birthdate", SqlDbType.Date).Value = Me.Birthdate
            objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Me.Address
            objCmd.Parameters.Add("@Phone_Number", SqlDbType.VarChar).Value = Me.PhoneNumber
            objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Me.Email
            objCmd.Parameters.Add("@Job_Title", SqlDbType.VarChar).Value = Me.JobTitle
            objCmd.Parameters.Add("@SSN", SqlDbType.VarChar).Value = Me.SSNumber


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
            strSQL = "usp_InsertEmployee"

            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("@SSN", SqlDbType.VarChar).Value = Me.SSNumber
            objCmd.Parameters.Add("@First_Name", SqlDbType.VarChar).Value = Me.FirstName
            objCmd.Parameters.Add("@Last_Name", SqlDbType.VarChar).Value = Me.LastName
            objCmd.Parameters.Add("@Birthdate", SqlDbType.Date).Value = Me.Birthdate
            objCmd.Parameters.Add("@Address", SqlDbType.VarChar).Value = Me.Address
            objCmd.Parameters.Add("@Phone_Number", SqlDbType.VarChar).Value = Me.PhoneNumber
            objCmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = Me.Email
            objCmd.Parameters.Add("@Job_Title", SqlDbType.VarChar).Value = Me.JobTitle

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
            Dim strSQL As String = "usp_DeleteEmployees"
            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("@SSN", SqlDbType.VarChar).Value = Key
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