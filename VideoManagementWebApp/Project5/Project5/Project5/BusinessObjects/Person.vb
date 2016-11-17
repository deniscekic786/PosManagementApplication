Option Explicit On
Option Strict On
Imports System.IO
Imports System.Data                                     'Data Access (DataSet)
Imports System.Data.OleDb                               'OLEDB Provider for Connecting to MS Access Database
Imports System.Data.SqlClient                           'SQL Client Provider for Connecting to MS SQL Server Database
Imports System.Configuration                            'Configuration File for DB Connection


<Serializable()> _
Public MustInherit Class Person
    Inherits BusinessBase


    Private m_SSNumber As String
    Private m_FirstName As String
    Private m_LastName As String
    Private m_Birthdate As Date
    Private m_Age As Integer
    Private m_Address As String
    Private m_PhoneNumber As String
    Private Shared m_count As Integer = 0



    Public Property SSNumber() As String
        Get
            Return m_SSNumber
        End Get
        Set(ByVal value As String)
            If Len(Trim(value)) = 0 Then
                Throw New NotSupportedException("Business Rule: SSNum cannot be blank")
            End If

            If Not Me.IsNew Then
                Throw New NotSupportedException("Business Rule: SSNum is Write-once")
            End If
            If (Len(Trim(value)) <> 11) Then
                Throw New NotSupportedException("Value not exact Lenght")
            End If
            m_SSNumber = value
            MyBase.MarkDirty()
        End Set
    End Property

    Public Property FirstName() As String
        Get
            Return m_FirstName
        End Get
        Set(ByVal value As String)
            If Len(Trim(value)) = 0 Then
                Throw New NotSupportedException("Business Rule: Name cannot be blank")
            End If
            If Len(value) > 25 Then
                Throw New NotSupportedException("Business Rule: Name is too long")
            End If
            m_FirstName = value
            MyBase.MarkDirty()
        End Set
    End Property

    Public Property LastName() As String
        Get
            Return m_LastName
        End Get
        Set(ByVal value As String)
            If Len(Trim(value)) = 0 Then
                Throw New NotSupportedException("Business Rule: Name cannot be blank")
            End If
            If Len(value) > 25 Then
                Throw New NotSupportedException("Business Rule: Name is too long")
            End If
            m_LastName = value
            MyBase.MarkDirty()
        End Set
    End Property

    Public Overridable Property Birthdate() As Date
        Get
            m_Age = (Today().Year - m_Birthdate.Year)
            Return m_Birthdate
        End Get
        Set(ByVal value As Date)
            m_Birthdate = value
            MyBase.MarkDirty()
        End Set
    End Property

    Public ReadOnly Property Age() As Integer
        Get
            Return m_Age
        End Get
    End Property

    Public Property Address() As String
        Get
            Return m_Address
        End Get
        Set(ByVal value As String)
            If Len(Trim(value)) = 0 Then
                Throw New NotSupportedException("Business Rule: Address cannot be blank")
            End If
            m_Address = value
            MyBase.MarkDirty()
        End Set
    End Property

    Public Property PhoneNumber() As String
        Get
            Return m_PhoneNumber
        End Get

        Set(ByVal value As String)
            If Len(Trim(value)) = 0 Then
                Throw New NotSupportedException("Business Rule: Phone cannot be blank")
            End If
            m_PhoneNumber = value
            MyBase.MarkDirty()
        End Set
    End Property

    Public Shared Property Count() As Integer
        Get
            Return m_count
        End Get
        Set(ByVal value As Integer)
            m_count = value
        End Set
    End Property

    Public Sub New()

        m_SSNumber = ""
        m_FirstName = ""
        m_LastName = ""
        m_Birthdate = #1/1/1900#
        m_Age = 0
        m_Address = ""
        m_PhoneNumber = ""
        m_count = m_count + 1

    End Sub

    Public Sub New(ByVal ssn As String, ByVal FN As String, ByVal LN As String, ByVal BD As Date, ByVal ADD As String, ByVal PN As String, ByVal EM As String, ByVal JT As String)

        Me.SSNumber = ssn
        Me.FirstName = FN
        Me.LastName = LN
        Me.Birthdate = BD
        Me.Address = ADD
        Me.PhoneNumber = PN
        m_count = m_count + 1


    End Sub
    Public Overridable Sub print()


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
            objWrite.WriteLine(".....................................................................")
            objWrite.Close()
        Catch objE As Exception
            Throw New System.Exception("print all Method Error: " & objE.Message)
        End Try
    End Sub

End Class

