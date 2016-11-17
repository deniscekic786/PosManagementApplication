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
Public Class VideoGameList
    Inherits BusinessCollectionBase
    Private strConn As String = Me.GetDBConnectionString("WinClient.My.MySettings.SmallBusinessAppConnectionString")

    Public Shadows ReadOnly Property count() As Integer
        Get
            Try
                Return MyBase.Dictionary.Count()
            Catch objE As Exception
                Throw New System.Exception("Property count errory" & objE.Message)
            End Try
        End Get
    End Property


    Public Property item(ByVal key As String) As VideoGame
        Get
            Try
                Return CType(MyBase.Dictionary.Item(key), VideoGame)

            Catch objE As Exception
                Throw New System.Exception("Item Error: " & objE.Message)
            End Try
        End Get
        Set(ByVal value As VideoGame)
            Try
                If MyBase.Dictionary.Contains(key) Then
                    MyBase.Dictionary.Item(key) = value
                Else
                    Throw New System.ArgumentException("VideoGame Not Found, SET failed")
                End If
            Catch objA As ArgumentException
                Throw New System.ArgumentException(objA.Message)
            Catch objE As Exception
                Throw New System.Exception("Item Property Error: " & objE.Message)
            End Try
        End Set
    End Property

    Public Sub add(ByVal key As String, ByVal objDVD As VideoGame)
        Try
            MyBase.Dictionary.Add(key, objDVD)
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objY As ArgumentException
            Throw New System.ArgumentException("Duplicate Key Error: " & objY.Message)
        Catch objE As Exception
            Throw New System.Exception("Add method error:" & objE.Message)
        End Try
    End Sub


    Public Sub Add(ByVal Idnum As String, ByVal titles As String, ByVal descript As String, ByVal ratings As Rating, ByVal salesprice As Decimal, ByVal rentalsrate As Decimal, ByVal latenessfees As Decimal, ByVal categories As VideoGame_Category, ByVal formats As VideoGame_System, ByVal availability As Boolean)
        Try
            Dim tempobjCustomer As VideoGame
            tempobjCustomer = New VideoGame()
            With tempobjCustomer
                .ID_Number = Idnum
                .Title = titles
                .Description = descript
                .EnumRating = ratings
                .Sale_Price = salesprice
                .Rental_Rate = rentalsrate
                .Late_Fee = latenessfees
                .category = categories
                .Format = formats
                .Availability = availability
            End With
            MyBase.Dictionary.Add(tempobjCustomer.ID_Number, tempobjCustomer)
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
    Public Function Edit(ByVal key As String, ByVal objEmployee As VideoGame) As Boolean
        Try
            Dim objitem As VideoGame
            objitem = CType(MyBase.Dictionary.Item(key), VideoGame)
            If objitem Is Nothing Then
                Return False
            Else
                objitem.ID_Number = objEmployee.ID_Number
                objitem.Title = objEmployee.Title
                objitem.Description = objEmployee.Description
                objitem.EnumRating = objEmployee.EnumRating
                objitem.Sale_Price = objEmployee.Sale_Price
                objitem.Rental_Rate = objEmployee.Rental_Rate
                objitem.Late_Fee = objEmployee.Late_Fee
                objitem.category = objEmployee.category
                objitem.Format = objEmployee.Format

                Return True
            End If
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objE As Exception
            Throw New System.Exception("EditItem Error: " & objE.Message)
        End Try
    End Function

    Public Function Edit(ByVal ID As String, ByVal Title As String, ByVal Description As String, ByVal EnumRating As Rating, ByVal SalesPrice As Decimal, ByVal RentalRate As Decimal, ByVal lateFee As Decimal, ByVal VideogameCategory As VideoGame_Category, ByVal VideogameFormats As VideoGame_System, ByVal availi As Boolean) As Boolean
        Try
            Dim objitem As VideoGame
            objitem = CType(MyBase.Dictionary.Item(ID), VideoGame)
            If objitem Is Nothing Then
                Return False
            Else
                objitem.Title = Title
                objitem.Description = Description
                objitem.EnumRating = CType(System.Enum.Parse(GetType(Rating), EnumRating.ToString()), Rating)
                objitem.Sale_Price = CDec(SalesPrice)
                objitem.Rental_Rate = CDec(RentalRate)
                objitem.Late_Fee = CDec(lateFee)
                objitem.category = CType(System.Enum.Parse(GetType(VideoGame_Category), VideogameCategory.ToString()), VideoGame_Category)
                objitem.Format = CType(System.Enum.Parse(GetType(VideoGame_System), VideogameFormats.ToString()), VideoGame_System)
                objitem.Availability = CBool(availi.ToString())
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
            Dim objItem As VideoGame
            objItem = CType(MyBase.Dictionary.Item(key), VideoGame)
            If objItem Is Nothing Then
                Return False
            Else
                objItem.Print()
                Return True
            End If
        Catch objX As ArgumentNullException
            Throw New System.ArgumentNullException("Invalid Key Error: " & objX.Message)
        Catch objE As Exception
            Throw New System.Exception("Edit parameterized Error: " & objE.Message)
        End Try
    End Function

    Public Sub PrintAll()
        Try
            Dim objDictionaryEntry As DictionaryEntry
            Dim objItem As VideoGame
            For Each objDictionaryEntry In MyBase.Dictionary
                objItem = CType(objDictionaryEntry.Value, VideoGame)
                objItem.Print()
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
    '        Dim objemp As VideoGame
    '        If Not File.Exists("VideoGameData.txt") Then
    '            File.Create("VideoGameData.txt")
    '            Dim objFile As New StreamWriter("VideoGameData.txt")
    '            objFile.Close()
    '        End If
    '        Dim objDataFile As New StreamReader("VideoGameData.txt")
    '        Do While objDataFile.Peek <> -1
    '            Dim strLine As String = objDataFile.ReadLine
    '            Dim tempArray() As String = Split(strLine, ",")


    '            objemp = New VideoGame()
    '            With objemp
    '                .ID_Number = tempArray(0)
    '                .Title = tempArray(1)
    '                .Description = tempArray(2)
    '                .EnumRating = CType(System.Enum.Parse(GetType(Rating), tempArray(3).ToString()), Rating)
    '                .Sale_Price = CDec(tempArray(4))
    '                .Rental_Rate = CDec(tempArray(5))
    '                .Late_Fee = CDec(tempArray(6))
    '                .category = CType(System.Enum.Parse(GetType(VideoGame_Category), tempArray(7).ToString()), VideoGame_Category)
    '                .Format = CType(System.Enum.Parse(GetType(VideoGame_System), tempArray(8).ToString()), VideoGame_System)
    '                .Availability = CBool(tempArray(9))
    '            End With
    '            add(objemp.ID_Number, objemp)
    '        Loop
    '        objDataFile.Close()
    '    Catch objE As Exception
    '        Throw New System.Exception("Load Method Error: " & objE.Message)
    '    End Try
    'End Sub
    'Public Sub save()

    '    Try
    '        Dim objWrite As New StreamWriter("VideoGameData.txt", False)
    '        Dim objDictionaryEntry As DictionaryEntry
    '        Dim objItem As VideoGame

    '        For Each objDictionaryEntry In MyBase.Dictionary
    '            objItem = CType(objDictionaryEntry.Value, VideoGame)

    '            objWrite.WriteLine(objItem.ID_Number & "," &
    '                               objItem.Title & "," &
    '                               objItem.Description & "," & _
    '                               objItem.EnumRating.ToString() & "," & _
    '                               objItem.Sale_Price & "," & _
    '                               objItem.Rental_Rate & "," & _
    '                               objItem.Late_Fee & "," & _
    '                               objItem.category.ToString() & "," & _
    '                               objItem.Format.ToString() & "," & _
    '                               objItem.Availability.ToString())
    '        Next
    '        objWrite.Close()
    '    Catch objE As Exception
    '        Throw New System.Exception("Save Method Error: " & objE.Message)
    '    End Try
    'End Sub
    Public Overrides Function DeferredDelete(ByVal Key As String) As Boolean

        Dim objDEntry As DictionaryEntry
        Dim objItem As VideoGame

        'Search for Object to Mark Deferred Delete
        For Each objDEntry In MyBase.Dictionary
            objItem = CType(objDEntry.Value, VideoGame)
            'Find object
            If objItem.ID_Number = Key Then
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

    Public Shared Function Create() As VideoGameList
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
    Protected Shared Function DataPortal_Create() As VideoGameList
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
            Dim strSQL As String = "SELECT * FROM VideoGame"
            Dim objCmd As New SqlCommand(strSQL, objConn)

            Dim objDR As SqlDataReader = objCmd.ExecuteReader
            If objDR.HasRows Then
                Do While objDR.Read
                    Dim objItem As New VideoGame
                    Dim strKey As String = objDR.GetString(0)
                    objItem.Load(strKey)
                    Me.add(objItem.ID_Number, objItem)
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
            Dim objChild As VideoGame

            'Step 2-Use For..Each loop to iterate through Collection
            For Each objDictionaryEntry In MyBase.Dictionary
                'Step 3-Convert DictionaryEntry pointer returned to Type Person
                objChild = CType(objDictionaryEntry.Value, VideoGame)

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
            Dim objItem As VideoGame

            'Step 2-Use For..Each loop to iterate through Collection
            For Each objDictionaryEntry In MyBase.Dictionary
                'Step 3-Convert DictionaryEntry pointer returned to Type Person
                objItem = CType(objDictionaryEntry.Value, VideoGame)

                'Step 4-Find target object based on key
                'YOU WILL NEED TO SELECT THE CORRECT PROPERTY
                If objItem.ID_Number = Key Then

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
    Public Function ToArray() As VideoGame()
        'Declare an empty array of Business Class
        Dim ArrayName(MyBase.Dictionary.Count - 1) As VideoGame

        'Use Shared CopyTo() Method of Dictionary Class to convert Collection to Array
        MyBase.Dictionary.Values.CopyTo(ArrayName, 0)
        Return ArrayName
    End Function

    Protected Function GetDBConnectionString(ByVal Key As String) As String
        Dim objConnSetting As ConnectionStringSettings = ConfigurationManager.ConnectionStrings(Key)
        Return objConnSetting.ConnectionString
    End Function









End Class
