Option Explicit On
Option Strict On
Imports System.IO
Imports System.Data                                     'Data Access (DataSet)
Imports System.Data.OleDb                               'OLEDB Provider for Connecting to MS Access Database
Imports System.Data.SqlClient                           'SQL Client Provider for Connecting to MS SQL Server Database
Imports System.Configuration                            'Configuration File for DB Connection


<Serializable()> _
Public MustInherit Class Product
    Inherits BusinessBase

    Private m_IDNumber As String
    Private m_Title As String
    Private m_Description As String
    Private m_EnumRating As Rating
    Private m_Available As Boolean
    Private m_SalePrice As Decimal
    Private m_RentalRate As Decimal
    Private m_LateFee As Decimal


    Public Property ID_Number As String
        Get
            Return m_IDNumber
        End Get
        Set(ByVal value As String)
            If Len(Trim(value)) = 0 Then
                Throw New NotSupportedException("Business Rule: Id cannot be blank")
            End If

            If Not Me.IsNew Then
                Throw New NotSupportedException("Business Rule: Id is Write-once")
            End If
            If (Len(Trim(value)) <> 4) Then
                Throw New NotSupportedException("Value not exact Length")
            End If
            m_IDNumber = value
            MyBase.MarkDirty()
        End Set
    End Property

    Public Property Title As String
        Get
            Return m_Title
        End Get
        Set(ByVal value As String)
            If Len(Trim(value)) = 0 Then
                Throw New NotSupportedException("Business Rule: Name cannot be blank")
            End If
            m_Title = value
            MyBase.MarkDirty()
        End Set
    End Property

    Public Property Description As String
        Get
            Return m_Description
        End Get
        Set(ByVal value As String)
            If Len(Trim(value)) = 0 Then
                Throw New NotSupportedException("Business Rule: Name cannot be blank")
            End If
            m_Description = value
            MyBase.MarkDirty()
        End Set
    End Property

    Public Property EnumRating As Rating
        Get
            Return m_EnumRating
        End Get
        Set(ByVal value As Rating)
            m_EnumRating = value
            MyBase.MarkDirty()
        End Set
    End Property

    Public Property Availability As Boolean
        Get
            Return m_Available
        End Get
        Set(ByVal value As Boolean)
            m_Available = value
            MyBase.MarkDirty()
        End Set
    End Property
    Public Property Sale_Price As Decimal
        Get
            Return m_SalePrice
        End Get
        Set(ByVal value As Decimal)
            m_SalePrice = value
            MyBase.MarkDirty()
        End Set
    End Property
    Public Property Rental_Rate As Decimal
        Get
            Return m_RentalRate
        End Get
        Set(ByVal value As Decimal)
            m_RentalRate = value
            MyBase.MarkDirty()
        End Set
    End Property
    Public Property Late_Fee As Decimal
        Get
            Return m_LateFee
        End Get
        Set(ByVal value As Decimal)
            m_LateFee = value
            MyBase.MarkDirty()
        End Set
    End Property

    Public Sub New()
        m_IDNumber = ""
        m_Title = ""
        m_Description = ""
        m_EnumRating = Rating.None
        m_Available = True
        m_SalePrice = 0
        m_RentalRate = 0
        m_LateFee = 0
    End Sub
    Public Sub New(ByVal idnum As String, ByVal titles As String, ByVal descript As String, ByVal ratings As Rating, ByVal salesprice As Decimal, ByVal rentalsrate As Decimal, ByVal latenessfees As Decimal)
        Me.ID_Number = idnum
        Me.Title = titles
        Me.Description = descript
        Me.EnumRating = ratings
        Me.Sale_Price = salesprice
        Me.Rental_Rate = rentalsrate
        Me.Late_Fee = latenessfees

    End Sub

    Public MustOverride Sub Print()


    Public MustOverride Sub Product_Rental()
    Public MustOverride Sub Product_Return()
    Public MustOverride Sub Product_Sell()
End Class