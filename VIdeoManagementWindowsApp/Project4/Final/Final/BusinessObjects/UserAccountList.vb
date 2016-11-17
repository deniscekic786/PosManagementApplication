Option Explicit On
Option Strict On

Imports System.IO                                       'File/IO
Imports System.Data                                     'Data Access (DataSet)
Imports System.Data.SqlClient                           'SQL Client Provider for Connecting to MS SQL Server Database
Imports System.Configuration                            'Configuration File for DB Connection

'Keep commented. will be configure later
'Imports System.Runtime.Serialization.Formatters.Binary  'Serialization Library
'Imports System.Runtime.Remoting                         'Remoting
'Imports System.Runtime.Remoting.Channels                'Remoting
'Imports System.Runtime.Remoting.Channels.Http           'Remoting 


<Serializable()> _
Public Class UserAccountList
    Inherits BusinessCollectionBase
    Public Const SIZE = 9
    Private m_arrUserAccountList(SIZE) As UserAccount
    Private strConn As String = Me.GetDBConnectionString("WinClient.My.MySettings.SmallBusinessAppConnectionString")
    Private m_gettingguid As String
    Private m_lastguid As String
    Public Property GettingGuid As String
        Get
            Return m_gettingguid
        End Get
        Set(ByVal value As String)
            m_gettingguid = value
        End Set
    End Property
    Public Property lastguid As String
        Get
            Return m_lastguid
        End Get
        Set(ByVal value As String)
            m_lastguid = value
        End Set
    End Property

    Public Shadows ReadOnly Property Count() As Integer
        Get
            Try
                Return MyBase.Dictionary.Count
            Catch objE As Exception
                Throw New System.Exception("count property error:" & objE.Message)
            End Try
        End Get
    End Property

    Public Property item(ByVal key As String) As UserAccount
        Get
            Try
                Return CType(MyBase.Dictionary.Item(key), UserAccount)
            Catch objE As Exception
                Throw New System.Exception("Item Error: " & objE.Message)
            End Try
        End Get
        Set(ByVal value As UserAccount)
            Try
                If MyBase.Dictionary.Contains(key) Then
                    MyBase.Dictionary.Item(key) = value
                Else
                    Throw New System.ArgumentException("User Not Found, SET failed")
                End If
            Catch objA As ArgumentException
                Throw New System.ArgumentException(objA.Message)
            Catch objE As Exception
                Throw New System.Exception("Item Property Error: " & objE.Message)
            End Try
        End Set
    End Property


    Public Sub Add(ByVal key As String, ByVal objUserAccount As UserAccount)
        Try
            MyBase.Dictionary.Add(key, objUserAccount)
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objY As ArgumentException
            Throw New System.ArgumentException("Duplicate Key Error: " & objY.Message)
        Catch objE As Exception
            Throw New System.Exception("Add method error:" & objE.Message)
        End Try
    End Sub
    Public Sub Add(ByVal Username As String, ByVal Password As String, ByVal Email As String)
        Try
            Dim objTempUserPointer As UserAccount
            objTempUserPointer = UserAccount.CreateAccount(Username, Password, Email)
            With objTempUserPointer
                .Username = Username
                .Password = Password
                .Email = Email
            End With
            MyBase.Dictionary.Add(objTempUserPointer.Username, objTempUserPointer)

        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objY As ArgumentException
            Throw New System.ArgumentException("Duplicate Key Error: " & objY.Message)
        Catch objE As Exception
            Throw New System.Exception("Add method error:" & objE.Message)
        End Try
    End Sub
    Public Function Edit(ByVal key As String, ByVal objUserAccount As UserAccount) As Boolean
        Try
            Dim objitem As UserAccount
            objitem = CType(MyBase.Dictionary.Item(key), UserAccount)
            If objitem Is Nothing Then
                Return False
            Else
                objitem.Username = objUserAccount.Username
                objitem.Password = objUserAccount.Password
                objitem.Email = objUserAccount.Email
                Return True
            End If
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objE As Exception
            Throw New System.Exception("EditItem Error: " & objE.Message)
        End Try
    End Function
    Public Function Edit(ByVal Key As String, ByVal username As String, ByVal password As String, ByVal email As String) As Boolean
        Try
            Dim objitem As UserAccount
            objitem = CType(MyBase.Dictionary.Item(Key), UserAccount)
            If objitem.UserAccountID = Key Then
                objitem.Username = username
                objitem.Password = password
                objitem.Email = email
                Return True
            Else
                Return False
            End If
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objE As Exception
            Throw New System.Exception("Edit parameterized Error: " & objE.Message)
        End Try
    End Function
    Public Function Remove(ByVal key As String) As Boolean
        Try
            If MyBase.Dictionary.Contains(key) Then
                MyBase.Dictionary.Remove(key)
                Return True
            Else
                Return False
            End If
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objE As Exception
            Throw New System.Exception("Remove Error: " & objE.Message)
        End Try
    End Function
    Public Shadows Sub Clear()

        Try
            MyBase.Dictionary.Clear()
        Catch objex As Exception
            Throw New System.Exception("Unexpected error clearing List. " & objex.Message)
        End Try

    End Sub
    Public Function ChangeUsername(ByVal UserAccountID As String, ByVal NewUsername As String) As Boolean
        Try
            Dim objDictionaryEntry As DictionaryEntry
            For Each objDictionaryEntry In MyBase.Dictionary
                Dim objitem As UserAccount
                objitem = CType(objDictionaryEntry.Value, UserAccount)
                If objitem.UserAccountID = UserAccountID Then
                    objitem.ChangeUsername(NewUsername)
                    Return True
                End If
            Next
            Return False
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid ID Error: " & objX.Message)
        Catch objE As Exception
            Throw New System.Exception("Change User Name Error: " & objE.Message)
        End Try
    End Function

    Public Function ChangePassword(ByVal Username As String, ByVal NewPassword As String) As Boolean
        Try
            Dim objDictionaryEntry As DictionaryEntry
            For Each objDictionaryEntry In MyBase.Dictionary
                Dim objitem As UserAccount
                objitem = CType(objDictionaryEntry.Value, UserAccount)
                If objitem.UserAccountID = Me.lastguid And objitem.Username = Username Then
                    objitem.ChangePassword(NewPassword)
                    Return True
                End If
            Next
            Return False
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Username Error: " & objX.Message)
        Catch objE As Exception
            Throw New System.Exception("Change Password Error: " & objE.Message)
        End Try
    End Function
    Public Function ChangeEmail(ByVal Username As String, ByVal NewEmail As String) As Boolean
        Try
            Dim objDictionaryEntry As DictionaryEntry
            For Each objDictionaryEntry In MyBase.Dictionary
                Dim objitem As UserAccount
                objitem = CType(objDictionaryEntry.Value, UserAccount)
                If objitem.UserAccountID = Me.lastguid And objitem.Username = Username Then
                    objitem.ChangeEmail(NewEmail)
                    Return True
                End If
            Next
            Return False
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Username Error: " & objX.Message)
        Catch objE As Exception
            Throw New System.Exception("Change Email Error: " & objE.Message)
        End Try
    End Function
    Public Function Authenticates(ByVal User As String, ByVal Pass As String) As Boolean
        Try
            Me.Load()
            Dim objDictionaryEntry As DictionaryEntry
            For Each objDictionaryEntry In MyBase.Dictionary
                Dim objitem As UserAccount
                objitem = CType(objDictionaryEntry.Value, UserAccount)
                Dim variable1 As Boolean = objitem.Authenticate(User, Pass)
                If variable1 = True Then
                    Return True
                End If
            Next
            Me.Clear()
            Return False
            Throw New System.ArgumentException("UserAccount not found")
        Catch objE As System.Exception
            Throw New System.Exception("Authenticate function error:" & objE.Message)
        End Try
    End Function
    'Public Function ToArray() As UserAccount()
    '    Dim arrUserAccountList(MyBase.Dictionary.Count - 1) As UserAccount
    '    MyBase.Dictionary.Values.CopyTo(arrUserAccountList, 0)
    '    Return arrUserAccountList
    'End Function

    'Public Sub load()
    '    Try
    '        Dim objusers As UserAccount
    '        If Not File.Exists("UserAccountData.txt") Then
    '            File.Create("UserAccountData.txt")
    '            Dim objFile As New StreamWriter("UserAccountData.txt")
    '            objFile.Close()
    '        End If
    '        Dim objDataFile As New StreamReader("UserAccountData.txt")
    '        Do While objDataFile.Peek <> -1
    '            Dim strLine As String = objDataFile.ReadLine
    '            Dim tempArray() As String = Split(strLine, ",")
    '            objusers = UserAccount.CreateAccount("", "", "")
    '            With objusers
    '                .UserAccountID = tempArray(0)
    '                .Username = tempArray(1)
    '                .Password = tempArray(2)
    '                .Email = tempArray(3)
    '            End With
    '            Add(objusers.Username, objusers)
    '        Loop
    '        objDataFile.Close()
    '    Catch objE As Exception
    '        Throw New System.Exception("Load Method Error: " & objE.Message)
    '    End Try
    'End Sub

    'Public Sub save()
    '    Try


    '        Dim objWrite As New StreamWriter("UserAccountData.txt", False)
    '        Dim objDictionaryEntry As DictionaryEntry
    '        Dim objItem As UserAccount
    '        For Each objDictionaryEntry In MyBase.Dictionary
    '            objItem = CType(objDictionaryEntry.Value, UserAccount)
    '            objWrite.WriteLine(objItem.UserAccountID & "," &
    '                               objItem.Username & "," & _
    '                   objItem.Password & "," & _
    '                   objItem.Email)
    '        Next
    '        objWrite.Close()
    '    Catch objE As Exception
    '        Throw New System.Exception("Save Method Error: " & objE.Message)
    '    End Try
    'End Sub

    Public Overrides Function DeferredDelete(ByVal Key As String) As Boolean

        Dim objDEntry As DictionaryEntry
        Dim objItem As UserAccount

        'Search for Object to Mark Deferred Delete
        For Each objDEntry In MyBase.Dictionary
            objItem = CType(objDEntry.Value, UserAccount)
            'Find object
            If objItem.UserAccountID = Key Then
                'If OLD or NOT New 
                If Not objItem.IsNew Then
                    'Mark Object for Deletion
                    objItem.DeferredDelete()
                    'Return True and exit
                    Return True
                Else
                    'Object found but IsNew Do not mark for deletion.
                    'return false and exit
                    Return False
                End If
            End If
        Next

        'Search Completed. Object Not found return False
        Return False

    End Function


    Public Shared Function Create() As UserAccountList
        'Calls Local DatPortal_Create() To do the work
        Return DataPortal_Create()

    End Function

    Public Sub Load()
        'Calls Local DatPortal_Fetch() To do the work
        DataPortal_Fetch()

    End Sub

    ' ''' <remarks></remarks>
    Public Sub Save()
        '    'Verify there are dirty objects in Collection
        '    'Only modify if dirty, otherwise do nothing in this method
        If IsDirty Then
            '        'Dirty Collection, go ahead and update
            DataPortal_Save()
        End If

    End Sub
    Public Sub ImmediateDelete(ByVal Key As String)
        'Calls Local DatPortal_DeleteObject() To do the work
        DataPortal_Delete(Key)
    End Sub
    Protected Shared Function DataPortal_Create() As UserAccountList
        'Create object and assign default values from database etc.

        'Step1 - Create object of this Class.
        'Step2 - Execute any database operation required to initialize object with data from 
        'database

        Return Nothing
    End Function

    Public Function ReturnGuid(ByVal key As String) As String
        Try
            Dim objDictionaryEntry As DictionaryEntry
            Dim objItem As UserAccount
            For Each objDictionaryEntry In MyBase.Dictionary
                objItem = CType(objDictionaryEntry.Value, UserAccount)
                If objItem.Username = key Then
                    GettingGuid = objItem.UserAccountID
                End If
            Next
        Catch objE As Exception
            Throw New System.Exception("Return Guid Error! " & objE.Message)
        End Try
        Return GettingGuid
    End Function
    Protected Sub DataPortal_Fetch()
        Dim objConn As New SqlConnection(strConn)
        Try
            objConn.Open()
            Dim strSQL As String = "SELECT * FROM Users_Table"
            Dim objCmd As New SqlCommand(strSQL, objConn)

            Dim objDR As SqlDataReader = objCmd.ExecuteReader
            If objDR.HasRows Then
                Do While objDR.Read
                    Dim objItem As New UserAccount
                    Dim strKey As String = objDR.GetString(0)
                    objItem.Load(strKey)
                    Me.Add(objItem.UserAccountID, objItem)
                    objItem = Nothing
                Loop
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
    End Sub
    Protected Sub DataPortal_Save()
        'Iterates through Collection, Calling Each CHILD object.Save() method
        'CHILD Objects save themselves
        'Step A- Begin Error trapping
        Try
            'Step 1-Step 1-Create Temporary Person and Dictionary object POINTERS
            Dim objDictionaryEntry As DictionaryEntry
            Dim objChild As UserAccount

            'Step 2-Use For..Each loop to iterate through Collection
            For Each objDictionaryEntry In MyBase.Dictionary
                'Step 3-Convert DictionaryEntry pointer returned to Type Person
                objChild = CType(objDictionaryEntry.Value, UserAccount)

                'Step 4-Call Child to Save itself
                objChild.Save()

            Next
            'Step B-Traps for general exceptions.  
        Catch objE As Exception
            'Step C-Throw an general exceptions
            Throw New System.Exception("Save Error! " & objE.Message)
        End Try
    End Sub

    Protected Sub DataPortal_Delete(ByVal Key As String)
        'Iterates through Collection, Calling Each CHILD object.Delete() method
        'CHILD Objects Delete themselves

        'Step A- Begin Error trapping
        Try
            'Step 1-Step 1-Create Temporary Person and Dictionary object POINTERS
            Dim objDictionaryEntry As DictionaryEntry
            Dim objItem As UserAccount

            'Step 2-Use For..Each loop to iterate through Collection
            For Each objDictionaryEntry In MyBase.Dictionary
                'Step 3-Convert DictionaryEntry pointer returned to Type Person
                objItem = CType(objDictionaryEntry.Value, UserAccount)

                'Step 4-Find target object based on key
                'YOU WILL NEED TO SELECT THE CORRECT PROPERTY
                If objItem.UserAccountID = Key Then

                    'Step 5-Object deletes itself
                    objItem.ImmediateDelete(Key)

                End If

            Next
            'Step B-Traps for general exceptions.  
        Catch objE As Exception
            'Step C-Throw an general exceptions
            Throw New System.Exception("Save Error! " & objE.Message)
        End Try

    End Sub

    '*********************************************************************
    'Methods used to assist other methods or maintenance

    '*********************************************************************
    'Methods used to assist other methods or maintenance
    Public Function ToArray() As UserAccount()
        'Declare an empty array of Business Class
        Dim ArrayName(MyBase.Dictionary.Count - 1) As UserAccount

        'Use Shared CopyTo() Method of Dictionary Class to convert Collection to Array
        MyBase.Dictionary.Values.CopyTo(ArrayName, 0)
        Return ArrayName
    End Function

    Protected Function GetDBConnectionString(ByVal Key As String) As String
        Dim objConnSetting As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(Key)
        Return objConnSetting.ConnectionString
    End Function
    Public Sub New()
        m_gettingguid = ""
        m_lastguid = ""
    End Sub




End Class


