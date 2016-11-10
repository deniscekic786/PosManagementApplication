Option Explicit On 
Option Strict On

Imports System.IO                                       'File/IO
Imports System.Data                                     'Data Access (DataSet)
Imports System.Data.OleDb                               'OLEDB Provider for Connecting to MS Access Database
Imports System.Data.SqlClient                           'SQL Client Provider for Connecting to MS SQL Server Database
Imports System.Configuration                            'Configuration File for DB Connection

''Imports System.configuration.dll

'Imports System.Configuration.ConfigurationManager.AppSettings

'Keep commented. will be configure later
'Imports System.Runtime.Serialization.Formatters.Binary  'Serialization Library
'Imports System.Runtime.Remoting                         'Remoting
'Imports System.Runtime.Remoting.Channels                'Remoting
'Imports System.Runtime.Remoting.Channels.Http           'Remoting 


<Serializable()> _
Public MustInherit Class BusinessBase
    'Implementing Business Rules New, Dirty, Deleted


#Region "Private Data"
    Private mflgIsDirty As Boolean = True
    Private mflgIsNew As Boolean = True
    Private mflgIsDeleted As Boolean = False
#End Region

#Region "Public Properties"
    'Returns the status of the IsNew Flag
    Public ReadOnly Property IsNew() As Boolean
        Get
            Return mflgIsNew
        End Get
    End Property
    'Returns the status of the IsDirty Flag
    Public Overridable ReadOnly Property IsDirty() As Boolean
        Get
            Return mflgIsDirty
        End Get
    End Property
    'Returns the status of the IsDeleted Flag
    Public Overridable ReadOnly Property IsDeleted() As Boolean
        Get
            Return mflgIsDeleted
        End Get
    End Property
#End Region

#Region "Private and Protected Methods"
    '*********************************************************************
    'Sets the IsDirty Flag to True
    Protected Sub MarkDirty()
        mflgIsDirty = True
    End Sub
    '*********************************************************************
    'Sets the IsDirty Flag to False
    Private Sub MarkClean()
        mflgIsDirty = False
    End Sub
    '*********************************************************************
    'Support for DATABASE UPDATE or INSERT Operations
    'Sets the IsNew Flag to True, Marks the Object as dirty
    Protected Sub MarkNew()
        mflgIsNew = True
        mflgIsDeleted = False
        MarkDirty()
    End Sub
    '*********************************************************************
    'Support for DATABASE UPDATE or INSERT Operations
    'Sets the IsNew Flag to False, Marks the Object as clean
    Protected Sub MarkOld()
        mflgIsNew = False
        MarkClean()
    End Sub
    '*********************************************************************
    'Support for DEFFERED DELETE Operation
    'Sets the IsDeleted Flag to True, Marks the Object as clean
    Protected Sub MarkDeleted()
        mflgIsDeleted = True
        MarkDirty()
    End Sub

#End Region

#Region "Public Methods"
    '*********************************************************************
    'Support for Deferred Deletion. Marks the object for deleting later not immediately
    Public Sub DeferredDelete()
        'Call MarkDeleted() method to Mark the Object for Deferred Delete
        MarkDeleted()
    End Sub

#End Region



End Class
