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
Public Class EmployeeList
    Inherits BusinessCollectionBase

    Public Const SIZE = 9
    Private strConn As String = Me.GetDBConnectionString("WinClient.My.MySettings.SmallBusinessAppConnectionString")
    Private m_arrEmployeeList(SIZE) As Employee
    Public Shadows ReadOnly Property Count() As Integer
        Get
            Try
                Return MyBase.Dictionary.Count
            Catch objE As Exception
                Throw New System.Exception("count property error:" & objE.Message)
            End Try
        End Get
    End Property

    Public Property item(ByVal key As String) As Employee
        Get
            Try
                Return CType(MyBase.Dictionary.Item(key), Employee)

            Catch objE As Exception
                Throw New System.Exception("Item Error: " & objE.Message)
            End Try
        End Get

        Set(ByVal value As Employee)
            Try
                If MyBase.Dictionary.Contains(key) Then
                    MyBase.Dictionary.Item(key) = value
                Else
                    Throw New System.ArgumentException("Customer Not Found, SET failed")
                End If
            Catch objA As ArgumentException
                Throw New System.ArgumentException(objA.Message)
            Catch objE As Exception
                Throw New System.Exception("Item Property Error: " & objE.Message)
            End Try
        End Set
    End Property


    Public Sub Add(ByVal key As String, ByVal objEmployee As Employee)
        Try
            MyBase.Dictionary.Add(key, objEmployee)
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objY As ArgumentException
            Throw New System.ArgumentException("Duplicate Key Error: " & objY.Message)
        Catch objE As Exception
            Throw New System.Exception("Add method error:" & objE.Message)
        End Try
    End Sub
    Public Sub Add(ByVal SSNumber As String, ByVal FirstName As String, ByVal LastName As String, ByVal Birthdate As String, ByVal Address As String, ByVal PhoneNumber As String, ByVal Email As String, ByVal JobTitle As String)
        Try
            Dim tempobjEmpl As Employee
            tempobjEmpl = New Employee()
            With tempobjEmpl
                .SSNumber = SSNumber
                .FirstName = FirstName
                .LastName = LastName
                .Birthdate = CDate(Birthdate)
                .Address = Address
                .PhoneNumber = PhoneNumber
                .Email = Email
                .JobTitle = JobTitle
            End With
            MyBase.Dictionary.Add(tempobjEmpl.SSNumber, tempobjEmpl)
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objY As ArgumentException
            Throw New System.ArgumentException("Duplicate Key Error: " & objY.Message)
        Catch objE As Exception
            Throw New System.Exception("Add method error:" & objE.Message)
        End Try
    End Sub
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
    Public Function Edit(ByVal key As String, ByVal objEmployee As Employee) As Boolean
        Try
            Dim objitem As Employee
            objitem = CType(MyBase.Dictionary.Item(key), Employee)
            If objitem Is Nothing Then
                Return False
            Else
                objitem.FirstName = objEmployee.FirstName
                objitem.LastName = objEmployee.LastName
                objitem.Birthdate = objEmployee.Birthdate
                objitem.Address = objEmployee.Address
                objitem.PhoneNumber = objEmployee.PhoneNumber
                objitem.Email = objEmployee.Email
                objitem.JobTitle = objEmployee.JobTitle
                Return True
            End If
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objE As Exception
            Throw New System.Exception("EditItem Error: " & objE.Message)
        End Try
    End Function
    Public Function Edit(ByVal SSNum As String, ByVal FName As String, ByVal LName As String, ByVal BDate As String, ByVal Address As String, ByVal Phone As String, ByVal Email As String, ByVal Title As String) As Boolean
        Try

            Dim objitem As Employee
            objitem = CType(MyBase.Dictionary.Item(SSNum), Employee)
            If objitem Is Nothing Then
                Return False
            Else
                objitem.FirstName = FName
                objitem.LastName = LName
                objitem.Birthdate = CDate(BDate)
                objitem.Address = Address
                objitem.PhoneNumber = Phone
                objitem.Email = Email
                objitem.JobTitle = Title
                Return True
            End If

          


        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objE As Exception
            Throw New System.Exception("Edit parameterized Error: " & objE.Message)
        End Try
    End Function
    Public Function Print(ByVal key As String) As Boolean
        Try

            Dim objItem As Employee
            objItem = CType(MyBase.Dictionary.Item(key), Employee)
            If objItem Is Nothing Then
                Return False
            Else
                objItem.print()
                Return True
            End If
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objE As Exception
            Throw New System.Exception("Edit parameterized Error: " & objE.Message)
        End Try
    End Function
    Public Sub PrintAllEmployees()
        Try

            Dim objDictionaryEntry As DictionaryEntry
            Dim objItem As Employee
            For Each objDictionaryEntry In MyBase.Dictionary
                objItem = CType(objDictionaryEntry.Value, Employee)
                objItem.print()
            Next
        Catch objE As Exception
            Throw New System.Exception("PrintAll Method Error: " & objE.Message)

        End Try

    End Sub
    Public Shadows Sub Clear()
        Try
            MyBase.Dictionary.Clear()
        Catch objex As Exception
            Throw New System.Exception("Unexpected error clearing List. " & objex.Message)
        End Try

    End Sub
    'Public Function ToArray() As Employee()
    '    Dim arrEmployeeList(MyBase.Dictionary.Count - 1) As Employee
    '    MyBase.Dictionary.Values.CopyTo(arrEmployeeList, 0)
    '    Return arrEmployeeList
    'End Function
    'Public Sub load()
    '    Try
    '        Dim objemp As Employee
    '        If Not File.Exists("EmployeeData.txt") Then
    '            File.Create("EmployeeData.txt")
    '            Dim objFile As New StreamWriter("EmployeeData.txt")
    '            objFile.Close()
    '        End If
    '        Dim objDataFile As New StreamReader("EmployeeData.txt")
    '        Do While objDataFile.Peek <> -1
    '            Dim strLine As String = objDataFile.ReadLine
    '            Dim tempArray() As String = Split(strLine, ",")
    '            objemp = New Employee()
    '            With objemp
    '                .SSNumber = tempArray(0)
    '                .FirstName = tempArray(1)
    '                .LastName = tempArray(2)
    '                .Birthdate = CDate(tempArray(3))
    '                .Address = tempArray(4)
    '                .PhoneNumber = tempArray(5)
    '                .Email = tempArray(6)
    '                .JobTitle = tempArray(7)
    '            End With
    '            Add(objemp.SSNumber, objemp)
    '        Loop
    '        objDataFile.Close()
    '    Catch objE As Exception
    '        Throw New System.Exception("Load Method Error: " & objE.Message)
    '    End Try
    'End Sub
    'Public Sub save()

    '    Try


    '        Dim objWrite As New StreamWriter("EmployeeData.txt", False)
    '        Dim objDictionaryEntry As DictionaryEntry
    '        Dim objItem As Employee

    '        For Each objDictionaryEntry In MyBase.Dictionary
    '            objItem = CType(objDictionaryEntry.Value, Employee)
    '            objWrite.WriteLine(objItem.SSNumber & "," &
    '                               objItem.FirstName & "," & _
    '                               objItem.LastName & "," & _
    '                               objItem.Birthdate & "," & _
    '                               objItem.Address & "," & _
    '                               objItem.PhoneNumber & "," & _
    '                               objItem.Email & "," & _
    '                               objItem.JobTitle)
    '        Next
    '        objWrite.Close()
    '    Catch objE As Exception
    '        Throw New System.Exception("Save Method Error: " & objE.Message)
    '    End Try
    'End Sub

    Public Overrides Function DeferredDelete(ByVal Key As String) As Boolean

        Dim objDEntry As DictionaryEntry
        Dim objItem As Employee

        'Search for Object to Mark Deferred Delete
        For Each objDEntry In MyBase.Dictionary
            objItem = CType(objDEntry.Value, Employee)
            'Find object
            If objItem.SSNumber = Key Then
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


    Public Shared Function Create() As EmployeeList
        'Calls Local DatPortal_Create() To do the work
        Return DataPortal_Create()

    End Function

    Public Sub Load()
        'Calls Local DatPortal_Fetch() To do the work
        DataPortal_Fetch()

    End Sub

    ' ''' <remarks></remarks>
    Public Sub Save()
        'Verify there are dirty objects in Collection
        'Only modify if dirty, otherwise do nothing in this method
        If IsDirty Then
            'Dirty Collection, go ahead and update
            DataPortal_Save()
        End If

    End Sub
    Public Sub ImmediateDelete(ByVal Key As String)
        'Calls Local DatPortal_DeleteObject() To do the work
        DataPortal_Delete(Key)
    End Sub
    Protected Shared Function DataPortal_Create() As EmployeeList
        'Create object and assign default values from database etc.

        'Step1 - Create object of this Class.
        'Step2 - Execute any database operation required to initialize object with data from 
        'database

        Return Nothing
    End Function
    Protected Sub DataPortal_Fetch()
        Dim objConn As New SqlConnection(strConn)
        Try
            objConn.Open()
            Dim strSQL As String = "SELECT * FROM Employees"
            Dim objCmd As New SqlCommand(strSQL, objConn)

            Dim objDR As SqlDataReader = objCmd.ExecuteReader
            If objDR.HasRows Then
                Do While objDR.Read
                    Dim objItem As New Employee
                    Dim strKey As String = objDR.GetString(0)
                    objItem.Load(strKey)
                    Me.Add(objItem.SSNumber, objItem)
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
            Dim objChild As Employee

            'Step 2-Use For..Each loop to iterate through Collection
            For Each objDictionaryEntry In MyBase.Dictionary
                'Step 3-Convert DictionaryEntry pointer returned to Type Person
                objChild = CType(objDictionaryEntry.Value, Employee)

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
            Dim objItem As Employee

            'Step 2-Use For..Each loop to iterate through Collection
            For Each objDictionaryEntry In MyBase.Dictionary
                'Step 3-Convert DictionaryEntry pointer returned to Type Person
                objItem = CType(objDictionaryEntry.Value, Employee)

                'Step 4-Find target object based on key
                'YOU WILL NEED TO SELECT THE CORRECT PROPERTY
                If objItem.SSNumber = Key Then

                    'Step 5-Object deletes itself
                    objItem.ImmediateDelete(Key)

                End If

            Next
            'Step B-Traps for general exceptions.  
        Catch objE As Exception
            'Step C-Throw an general exceptions
            Throw New System.Exception("Delete Error! " & objE.Message)
        End Try

    End Sub

    '*********************************************************************
    'Methods used to assist other methods or maintenance

    '*********************************************************************
    'Methods used to assist other methods or maintenance
    Public Function ToArray() As Employee()
        'Declare an empty array of Business Class
        Dim ArrayName(MyBase.Dictionary.Count - 1) As Employee

        'Use Shared CopyTo() Method of Dictionary Class to convert Collection to Array
        MyBase.Dictionary.Values.CopyTo(ArrayName, 0)
        Return ArrayName
    End Function

    Protected Function GetDBConnectionString(ByVal Key As String) As String
        Dim objConnSetting As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(Key)
        Return objConnSetting.ConnectionString
    End Function




End Class

