Option Explicit On 
Option Strict On

Imports System.IO                                       'File/IO
Imports System.Data                                     'Data Access (DataSet)
Imports System.Data.OleDb                               'OLEDB Provider
Imports System.Data.SqlClient                           'SQL Client Provider for Connecting to MS SQL Server Database
Imports System.Configuration                            'Configuration File for DB Connection
Imports System.Collections                              'Collection Library

'Configuration File for DB Connection
'Keep commented. will be configure later
'Imports System.Runtime.Serialization.Formatters.Binary  'Serialization Library
'Imports System.Runtime.Remoting                         'Remoting
'Imports System.Runtime.Remoting.Channels                'Remoting
'Imports System.Runtime.Remoting.Channels.Http           'Remoting 

<Serializable()> _
Public MustInherit Class BusinessCollectionBase
    Inherits DictionaryBase

#Region " Dirty Object Business Logic "
    'Search and Find the first Dirty Child Object
    Public ReadOnly Property IsDirty() As Boolean
        Get
            'Any Dirty Object make the entire collection dirty
            Dim objDEntry As DictionaryEntry
            Dim objItem As BusinessBase
            For Each objDEntry In MyBase.Dictionary
                objItem = CType(objDEntry.Value, BusinessBase)
                If objItem.IsDirty Then Return True
            Next
            Return False
        End Get
    End Property
#End Region

#Region "MustOverride Methods"

    '*********************************************************************
    'MustOverride Print() method must be implemented derived classes
    ''' <summary>
    ''' MustOverride Function DeferredDelete(Key) 
    ''' Purpose - Forced upon any class that inherits from this BusinessCollectionBase
    ''' Derived classes MUST OVERRIDE and implement this method
    ''' otherwise they cannot compile.  
    ''' </summary>
    Public MustOverride Function DeferredDelete(ByVal Key As String) As Boolean

#End Region

End Class
