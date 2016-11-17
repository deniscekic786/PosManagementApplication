Option Explicit On
Option Strict On

Imports System.IO                                       'File/IO
Imports System.Data                                     'Data Access (DataSet)                              'OLEDB Provider
Imports System.Data.SqlClient                           'SQL Client Provider for Connecting to MS SQL Server Database
Imports System.Configuration                            'Configuration File for DB Connection

'Keep commented. will be configure later
'Imports System.Runtime.Serialization.Formatters.Binary  'Serialization Library
'Imports System.Runtime.Remoting                         'Remoting
'Imports System.Runtime.Remoting.Channels                'Remoting
'Imports System.Runtime.Remoting.Channels.Http           'Remoting 


<Serializable()> _
Public Class CustomerList
    Inherits BusinessCollectionBase
    Public Const SIZE = 9
    Private m_arrCustomerList(SIZE) As Customer
    Private strConn As String = Me.GetDBConnectionString("WinClient.My.MySettings.SmallBusinessAppConnectionString")

    Public Shadows ReadOnly Property Count() As Integer
        Get

            Try
                Return MyBase.Dictionary.Count
            Catch objE As Exception
                Throw New System.Exception("count property error:" & objE.Message)
            End Try
        End Get
    End Property
    Public Property item(ByVal key As String) As Customer
        Get
            Try
                Return CType(MyBase.Dictionary.Item(key), Customer)

            Catch objE As Exception
                Throw New System.Exception("Item Error: " & objE.Message)
            End Try
        End Get


        Set(ByVal value As Customer)
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


    Public Sub Add(ByVal key As String, ByVal objCustomerList As Customer)
        Try
            MyBase.Dictionary.Add(key, objCustomerList)
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objY As ArgumentException
            Throw New System.ArgumentException("Duplicate Key Error: " & objY.Message)
        Catch objE As Exception
            Throw New System.Exception("Add method error:" & objE.Message)
        End Try
    End Sub
    Public Sub Add(ByVal Idnumber As String, ByVal FirstName As String, ByVal LastName As String, ByVal SSNumber As String, ByVal Birthdate As String, ByVal Address As String, ByVal PhoneNumber As String, ByVal Email As String)
        Try
            Dim tempobjCustomer As Customer
            tempobjCustomer = New Customer()
            With tempobjCustomer
                .IDNumber = Idnumber
                .FirstName = FirstName
                .LastName = LastName
                .SSNumber = SSNumber
                .Birthdate = CDate(Birthdate)
                .Address = Address
                .PhoneNumber = PhoneNumber
                .Email = Email
            End With
            MyBase.Dictionary.Add(tempobjCustomer.IDNumber, tempobjCustomer)
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objY As ArgumentException
            Throw New System.ArgumentException("Duplicate Key Error: " & objY.Message)
        Catch objE As Exception
            Throw New System.Exception("Add method error:" & objE.Message)
        End Try
    End Sub
    'Public Function Remove(ByVal key As String) As Boolean
    '    Try
    '        If MyBase.Dictionary.Contains(key) Then
    '            MyBase.Dictionary.Remove(key)
    '            Return True
    '        Else
    '            Return False
    '        End If
    '    Catch objX As ArgumentNullException
    '        Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
    '    Catch objE As Exception
    '        Throw New System.Exception("Remove Error: " & objE.Message)
    '    End Try
    'End Function
    Public Function Edit(ByVal key As String, ByVal objCustomerList As Customer) As Boolean
        Try
            Dim objitem As Customer
            objitem = CType(MyBase.Dictionary.Item(key), Customer)
            If objitem Is Nothing Then
                Return False
            Else
                objitem.FirstName = objCustomerList.FirstName
                objitem.LastName = objCustomerList.LastName
                objitem.SSNumber = objCustomerList.SSNumber
                objitem.Birthdate = objCustomerList.Birthdate
                objitem.Address = objCustomerList.Address
                objitem.PhoneNumber = objCustomerList.PhoneNumber
                objitem.Email = objCustomerList.Email
                Return True
            End If
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objE As Exception
            Throw New System.Exception("EditItem Error: " & objE.Message)
        End Try
    End Function
    Public Function Edit(ByVal Idnumber As String, ByVal FName As String, ByVal LName As String, ByVal BDate As String, ByVal Address As String, ByVal Phone As String, ByVal Email As String) As Boolean
        Try

            Dim objitem As Customer
            objitem = CType(MyBase.Dictionary.Item(Idnumber), Customer)
            If objitem Is Nothing Then
                Return False
            Else
                objitem.FirstName = FName
                objitem.LastName = LName
                objitem.Birthdate = CDate(BDate)
                objitem.Address = Address
                objitem.PhoneNumber = Phone
                objitem.Email = Email
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

            Dim objItem As Customer
            objItem = CType(MyBase.Dictionary.Item(key), Customer)
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
    Public Sub PrintAllCustomer()
        Try

            Dim objDictionaryEntry As DictionaryEntry
            Dim objItem As Customer
            For Each objDictionaryEntry In MyBase.Dictionary
                objItem = CType(objDictionaryEntry.Value, Customer)
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
   
    'Public Sub load()
    '    Try
    '        Dim objCustomer As Customer
    '        If Not File.Exists("CustomerData.txt") Then
    '            File.Create("CustomerData.txt")
    '            Dim objFile As New StreamWriter("CustomerData.txt")
    '            objFile.Close()
    '        End If
    '        Dim objDataFile As New StreamReader("CustomerData.txt")
    '        Do While objDataFile.Peek <> -1
    '            Dim strLine As String = objDataFile.ReadLine
    '            Dim tempArray() As String = Split(strLine, ",")
    '            objCustomer = New Customer()
    '            With objCustomer
    '                .IDNumber = tempArray(0)
    '                .FirstName = tempArray(1)
    '                .LastName = tempArray(2)
    '                .SSNumber = tempArray(3)
    '                .Birthdate = CDate(tempArray(4))
    '                .Address = tempArray(5)
    '                .PhoneNumber = tempArray(6)
    '                .Email = tempArray(7)
    '            End With
    '            Add(objCustomer.IDNumber, objCustomer)
    '        Loop
    '        objDataFile.Close()
    '    Catch objE As Exception
    '        Throw New System.Exception("Load Method Error: " & objE.Message)
    '    End Try
    'End Sub
    'Public Sub save()

    '    Try


    '        Dim objWrite As New StreamWriter("CustomerData.txt", False)
    '        Dim objDictionaryEntry As DictionaryEntry
    '        Dim objItem As Customer

    '        For Each objDictionaryEntry In MyBase.Dictionary
    '            objItem = CType(objDictionaryEntry.Value, Customer)
    '            objWrite.WriteLine(objItem.IDNumber & "," &
    '                               objItem.FirstName & "," & _
    '                               objItem.LastName & "," & _
    '                               objItem.SSNumber & "," & _
    '                               objItem.Birthdate & "," & _
    '                               objItem.Address & "," & _
    '                               objItem.PhoneNumber & "," & _
    '                               objItem.Email)
    '        Next
    '        objWrite.Close()
    '    Catch objE As Exception
    '        Throw New System.Exception("Save Method Error: " & objE.Message)
    '    End Try
    'End Sub

    Public Overrides Function DeferredDelete(ByVal Key As String) As Boolean

        Dim objDEntry As DictionaryEntry
        Dim objItem As Customer

        'Search for Object to Mark Deferred Delete
        For Each objDEntry In MyBase.Dictionary
            objItem = CType(objDEntry.Value, Customer)
            'Find object
            If objItem.IDNumber = Key Then
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


    Public Shared Function Create() As CustomerList
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
    Protected Shared Function DataPortal_Create() As CustomerList
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
            Dim strSQL As String = "Select * From Customers"
            Dim objCmd As New SqlCommand(strSQL, objConn)

            Dim objDR As SqlDataReader = objCmd.ExecuteReader
            If objDR.HasRows Then
                Do While objDR.Read
                    Dim objItem As New Customer
                    Dim strKey As String = objDR.GetString(0)
                    objItem.Load(strKey)
                    Me.Add(objItem.IDNumber, objItem)
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
        Try
            'Step 1-Step 1-Create Temporary Person and Dictionary object POINTERS
            Dim objDictionaryEntry As DictionaryEntry
            Dim objChild As Customer

            'Step 2-Use For..Each loop to iterate through Collection
            For Each objDictionaryEntry In MyBase.Dictionary
                'Step 3-Convert DictionaryEntry pointer returned to Type Person
                objChild = CType(objDictionaryEntry.Value, Customer)

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
            Dim objItem As Customer

            'Step 2-Use For..Each loop to iterate through Collection
            For Each objDictionaryEntry In MyBase.Dictionary
                'Step 3-Convert DictionaryEntry pointer returned to Type Person
                objItem = CType(objDictionaryEntry.Value, Customer)

                'Step 4-Find target object based on key
                'YOU WILL NEED TO SELECT THE CORRECT PROPERTY
                If objItem.IDNumber = Key Then

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
    Public Function ToArray() As Customer()
        'Declare an empty array of Business Class
        Dim ArrayName(MyBase.Dictionary.Count - 1) As Customer

        'Use Shared CopyTo() Method of Dictionary Class to convert Collection to Array
        MyBase.Dictionary.Values.CopyTo(ArrayName, 0)
        Return ArrayName
    End Function

    Protected Function GetDBConnectionString(ByVal Key As String) As String
        Dim objConnSetting As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(Key)
        Return objConnSetting.ConnectionString
    End Function


End Class


