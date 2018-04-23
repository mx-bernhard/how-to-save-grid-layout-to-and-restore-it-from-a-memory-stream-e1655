Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Documents

Namespace DXGrid_GridLayout
	Partial Public Class Window1
		Inherits Window
		Private fileName As String = "gridLayout.xml"
		Shared Sub New()
			IsLayoutSavedProperty = DependencyProperty.Register("IsLayoutSaved", _
				GetType(Boolean), GetType(Window1))
		End Sub
		Public Sub New()
			InitializeComponent()
			IsLayoutSaved = System.IO.File.Exists(fileName)
			grid.DataSource = IssueList.GetData()
		End Sub
		Public Shared ReadOnly IsLayoutSavedProperty As DependencyProperty
		Public Property IsLayoutSaved() As Boolean
			Get
				Return CBool(GetValue(Window1.IsLayoutSavedProperty))
			End Get
			Set(ByVal value As Boolean)
				SetValue(Window1.IsLayoutSavedProperty, value)
			End Set
		End Property

		Private Sub SaveButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			grid.SaveLayoutToXml(fileName)
			IsLayoutSaved = True
		End Sub

		Private Sub LoadButton_Click(ByVal sender As Object, ByVal e As RoutedEventArgs)
			grid.RestoreLayoutFromXml(fileName)
		End Sub
	End Class
	Public Class IssueList
		Public Shared Function GetData() As List(Of IssueDataObject)
			Dim data As New List(Of IssueDataObject)()
			data.Add(New IssueDataObject() With {.IssueName = "Transaction History", _
				.IssueType = "Bug", .IsPrivate = True})
			data.Add(New IssueDataObject() With {.IssueName = "Ledger: Inconsistency", _
				.IssueType = "Bug", .IsPrivate = False})
			data.Add(New IssueDataObject() With {.IssueName = "Data Import", _
				.IssueType = "Request", .IsPrivate = False})
			data.Add(New IssueDataObject() With {.IssueName = "Data Archiving", _
				.IssueType = "Request", .IsPrivate = True})
			Return data
		End Function
	End Class

	Public Class IssueDataObject
		Private privateIssueName As String
		Public Property IssueName() As String
			Get
				Return privateIssueName
			End Get
			Set(ByVal value As String)
				privateIssueName = value
			End Set
		End Property
		Private privateIssueType As String
		Public Property IssueType() As String
			Get
				Return privateIssueType
			End Get
			Set(ByVal value As String)
				privateIssueType = value
			End Set
		End Property
		Private privateIsPrivate As Boolean
		Public Property IsPrivate() As Boolean
			Get
				Return privateIsPrivate
			End Get
			Set(ByVal value As Boolean)
				privateIsPrivate = value
			End Set
		End Property
	End Class
End Namespace
