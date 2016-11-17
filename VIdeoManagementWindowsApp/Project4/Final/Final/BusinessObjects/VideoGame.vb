Option Explicit On
Option Strict On
Imports System.IO
Imports System.Data                                     'Data Access (DataSet)
Imports System.Data.SqlClient                           'SQL Client Provider for Connecting to MS SQL Server Database
Imports System.Configuration                            'Configuration File for DB Connection

<Serializable()> _
Public Class VideoGame
    Inherits Product

    Private m_enumVideoGameCategory As VideoGame_Category
    Private m_enumVideoGameFormat As VideoGame_System

    Private strConn As String = Me.GetDBConnectionString("WinClient.My.MySettings.SmallBusinessAppConnectionString")
    Public Property category As VideoGame_Category
        Get
            Return m_enumVideoGameCategory
        End Get
        Set(ByVal value As VideoGame_Category)
            m_enumVideoGameCategory = value
            MyBase.MarkDirty()
        End Set
    End Property
    Public Property Format As VideoGame_System
        Get
            Return m_enumVideoGameFormat
        End Get
        Set(ByVal value As VideoGame_System)
            m_enumVideoGameFormat = value
            MyBase.MarkDirty()
        End Set
    End Property
    Public Sub New()
        Me.m_enumVideoGameCategory = VideoGame_Category.None
        Me.m_enumVideoGameFormat = VideoGame_System.None
    End Sub
    Public Sub New(ByVal idnum As String, ByVal titles As String, ByVal descript As String, ByVal ratings As Rating, ByVal salesprice As Decimal, ByVal rentalsrate As Decimal, ByVal latenessfees As Decimal, ByVal categories As VideoGame_Category, ByVal formats As VideoGame_System, ByVal avil As Boolean)
        MyBase.ID_Number = idnum
        MyBase.Title = titles
        MyBase.Description = descript
        MyBase.EnumRating = ratings
        MyBase.Sale_Price = salesprice
        MyBase.Rental_Rate = rentalsrate
        MyBase.Late_Fee = latenessfees
        Me.m_enumVideoGameCategory = categories
        Me.m_enumVideoGameFormat = formats
        MyBase.Availability = avil
    End Sub

    Public Overrides Sub Print()
        Try
            If Not File.Exists("Network_Printer.txt") Then
                File.Create("Network_Printer.txt")
                Dim objFile As New StreamWriter("Network_Printer.txt")
                objFile.Close()
            End If
            Dim objList As New StreamWriter("Network_Printer.txt", True)

            objList.WriteLine("------Video Games-----")
            objList.WriteLine("ID Number..... " & ID_Number)
            objList.WriteLine("Title..... " & Title)
            objList.WriteLine("Description..... " & Description)
            objList.WriteLine("Ratings..... " & EnumRating.ToString())
            objList.WriteLine("Sale Price..... " & Sale_Price)
            objList.WriteLine("Rental Rate..... " & Rental_Rate)
            objList.WriteLine("Late Fee..... " & Late_Fee)
            objList.WriteLine("Video Game Category....." & category.ToString())
            objList.WriteLine("Video Game System..... " & Format.ToString())
            objList.WriteLine("Video Game Availibility..... " & Availability.ToString())
            objList.WriteLine("............................................... ")
            objList.Close()
        Catch objE As Exception
            Throw New System.Exception("print all Method Error: " & objE.Message)
        End Try
    End Sub
    Public Shared Function Create() As VideoGame
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
            DataPortal_Delete(Me.ID_Number)

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
    Public Sub ImmediateDelete(ByVal Key As String)
        'Calls Local DatPortal_Delete() To do the work
        DataPortal_Delete(Key)
    End Sub
    Protected Shared Function DataPortal_Create() As VideoGame
        'Create object and assign default values from database etc.

        'ADD DATA ACCESS CODE HERE USING ADO.NET

        Return Nothing
    End Function
    Protected Sub DataPortal_Fetch(ByVal Key As String)
        Dim objConn As New SqlConnection(strConn)
        Try
            objConn.Open()
            Dim strSQL As String = "usp_SelectVideoGame"
            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("@VideoGame_ID", SqlDbType.VarChar).Value = Key
            Dim objDR As SqlDataReader = objCmd.ExecuteReader
            If objDR.HasRows Then
                objDR.Read()
                Me.ID_Number = CStr(objDR.Item(0))
                Me.Title = CStr(objDR.Item(1))
                Me.Description = CStr(objDR.Item(2))
                Me.Availability = CBool(objDR.Item(3))
                Me.Rental_Rate = CDec(objDR.Item(4))
                Me.Late_Fee = CDec(objDR.Item(5))
                Me.Sale_Price = CDec(objDR.Item(6))
                Me.category = CType(System.Enum.Parse(GetType(VideoGame_Category), objDR.Item(7).ToString()), VideoGame_Category)
                Me.EnumRating = CType(System.Enum.Parse(GetType(Rating), objDR.Item(8).ToString()), Rating)
                Me.Format = CType(System.Enum.Parse(GetType(VideoGame_System), objDR.Item(9).ToString()), VideoGame_System)
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
    Protected Sub DataPortal_Update()
        Dim objConn As New SqlConnection(strConn)
        Try
            objConn.Open()
            Dim strSQL As String
            strSQL = "usp_UpdateVideoGame"

            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("Title", SqlDbType.VarChar).Value = Me.Title
            objCmd.Parameters.Add("Description", SqlDbType.VarChar).Value = Me.Description
            objCmd.Parameters.Add("Rating", SqlDbType.VarChar).Value = Me.EnumRating.ToString()
            objCmd.Parameters.Add("Availibility", SqlDbType.Bit).Value = Me.Availability
            objCmd.Parameters.Add("Sale_Price", SqlDbType.VarChar).Value = Me.Sale_Price.ToString()
            objCmd.Parameters.Add("Rental_Rate", SqlDbType.VarChar).Value = Me.Rental_Rate.ToString()
            objCmd.Parameters.Add("Late_Fee", SqlDbType.VarChar).Value = Me.Late_Fee.ToString()
            objCmd.Parameters.Add("Category", SqlDbType.VarChar).Value = Me.category.ToString()
            objCmd.Parameters.Add("Format", SqlDbType.VarChar).Value = Me.Format.ToString()
            objCmd.Parameters.Add("@VideoGame_ID", SqlDbType.VarChar).Value = Me.ID_Number


            Dim intRecordsAffected As Integer = objCmd.ExecuteNonQuery()
            If intRecordsAffected <= 1 Then
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
    Protected Sub DataPortal_Insert()

        Dim objConn As New SqlConnection(strConn)
        Try
            objConn.Open()
            Dim strSQL As String
            strSQL = "usp_InsertVideoGame"

            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("@VideoGame_ID", SqlDbType.VarChar).Value = Me.ID_Number
            objCmd.Parameters.Add("Title", SqlDbType.VarChar).Value = Me.Title
            objCmd.Parameters.Add("Description", SqlDbType.VarChar).Value = Me.Description
            objCmd.Parameters.Add("Rating", SqlDbType.VarChar).Value = Me.EnumRating.ToString()
            objCmd.Parameters.Add("Availibility", SqlDbType.Bit).Value = Me.Availability
            objCmd.Parameters.Add("Sale_Price", SqlDbType.VarChar).Value = Me.Sale_Price.ToString()
            objCmd.Parameters.Add("Rental_Rate", SqlDbType.VarChar).Value = Me.Rental_Rate.ToString()
            objCmd.Parameters.Add("Late_Fee", SqlDbType.VarChar).Value = Me.Late_Fee.ToString()
            objCmd.Parameters.Add("Category", SqlDbType.VarChar).Value = Me.category.ToString()
            objCmd.Parameters.Add("Format", SqlDbType.VarChar).Value = Me.Format.ToString()

            Dim intRecordsAffected As Integer = objCmd.ExecuteNonQuery()
            If intRecordsAffected <= 1 Then
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
    Protected Sub DataPortal_Delete(ByVal Key As String)
        Dim objConn As New SqlConnection(strConn)
        Try
            objConn.Open()
            Dim strSQL As String = "usp_DeleteVideoGame"
            Dim objCmd As New SqlCommand(strSQL, objConn)
            objCmd.CommandType = CommandType.StoredProcedure
            objCmd.Parameters.Add("@VideoGame_ID", SqlDbType.VarChar).Value = Key
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









    Public Overrides Sub Product_Rental()

    End Sub

    Public Overrides Sub Product_Return()

    End Sub

    Public Overrides Sub Product_Sell()

    End Sub
End Class
