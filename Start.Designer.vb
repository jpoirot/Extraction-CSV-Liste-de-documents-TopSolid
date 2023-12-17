<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Start
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TextBoxProjectName = New System.Windows.Forms.TextBox()
        Me.TreeViewProjectFolders = New System.Windows.Forms.TreeView()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.CheckBoxRecursiveSelection = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.FolderBrowserDialogCSVDestination = New System.Windows.Forms.FolderBrowserDialog()
        Me.TextBoxSelectedCSVDestinationFolder = New System.Windows.Forms.TextBox()
        Me.FolderBrowserDialog = New System.Windows.Forms.Button()
        Me.ButtonExecute = New System.Windows.Forms.Button()
        Me.CheckedListBoxPropertyToExport = New System.Windows.Forms.CheckedListBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TextBoxCSVName = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'TextBoxProjectName
        '
        Me.TextBoxProjectName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxProjectName.Location = New System.Drawing.Point(322, 30)
        Me.TextBoxProjectName.Name = "TextBoxProjectName"
        Me.TextBoxProjectName.ReadOnly = True
        Me.TextBoxProjectName.Size = New System.Drawing.Size(445, 20)
        Me.TextBoxProjectName.TabIndex = 2
        '
        'TreeViewProjectFolders
        '
        Me.TreeViewProjectFolders.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TreeViewProjectFolders.CheckBoxes = True
        Me.TreeViewProjectFolders.Location = New System.Drawing.Point(12, 12)
        Me.TreeViewProjectFolders.Name = "TreeViewProjectFolders"
        Me.TreeViewProjectFolders.Size = New System.Drawing.Size(300, 399)
        Me.TreeViewProjectFolders.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(319, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Nom projet courant"
        '
        'CheckBoxRecursiveSelection
        '
        Me.CheckBoxRecursiveSelection.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBoxRecursiveSelection.AutoSize = True
        Me.CheckBoxRecursiveSelection.Checked = True
        Me.CheckBoxRecursiveSelection.CheckState = System.Windows.Forms.CheckState.Checked
        Me.CheckBoxRecursiveSelection.Location = New System.Drawing.Point(12, 417)
        Me.CheckBoxRecursiveSelection.Name = "CheckBoxRecursiveSelection"
        Me.CheckBoxRecursiveSelection.Size = New System.Drawing.Size(116, 17)
        Me.CheckBoxRecursiveSelection.TabIndex = 9
        Me.CheckBoxRecursiveSelection.Text = "Sélection récursive"
        Me.CheckBoxRecursiveSelection.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(319, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(111, 13)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Chemin de destination"
        '
        'TextBoxSelectedCSVDestinationFolder
        '
        Me.TextBoxSelectedCSVDestinationFolder.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxSelectedCSVDestinationFolder.Location = New System.Drawing.Point(322, 69)
        Me.TextBoxSelectedCSVDestinationFolder.Name = "TextBoxSelectedCSVDestinationFolder"
        Me.TextBoxSelectedCSVDestinationFolder.ReadOnly = True
        Me.TextBoxSelectedCSVDestinationFolder.Size = New System.Drawing.Size(414, 20)
        Me.TextBoxSelectedCSVDestinationFolder.TabIndex = 11
        '
        'FolderBrowserDialog
        '
        Me.FolderBrowserDialog.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.FolderBrowserDialog.Location = New System.Drawing.Point(742, 69)
        Me.FolderBrowserDialog.Name = "FolderBrowserDialog"
        Me.FolderBrowserDialog.Size = New System.Drawing.Size(25, 20)
        Me.FolderBrowserDialog.TabIndex = 12
        Me.FolderBrowserDialog.Text = "..."
        Me.FolderBrowserDialog.UseVisualStyleBackColor = True
        '
        'ButtonExecute
        '
        Me.ButtonExecute.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ButtonExecute.Location = New System.Drawing.Point(322, 411)
        Me.ButtonExecute.Name = "ButtonExecute"
        Me.ButtonExecute.Size = New System.Drawing.Size(445, 23)
        Me.ButtonExecute.TabIndex = 13
        Me.ButtonExecute.Text = "Exécuter Export"
        Me.ButtonExecute.UseVisualStyleBackColor = True
        '
        'CheckedListBoxPropertyToExport
        '
        Me.CheckedListBoxPropertyToExport.FormattingEnabled = True
        Me.CheckedListBoxPropertyToExport.Items.AddRange(New Object() {"Nom", "Désignation", "Référence", "Fabricant", "RéférenceFabricant", "Type de document"})
        Me.CheckedListBoxPropertyToExport.Location = New System.Drawing.Point(322, 147)
        Me.CheckedListBoxPropertyToExport.Name = "CheckedListBoxPropertyToExport"
        Me.CheckedListBoxPropertyToExport.Size = New System.Drawing.Size(445, 94)
        Me.CheckedListBoxPropertyToExport.TabIndex = 14
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(319, 131)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(99, 13)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Propriété à exporter"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(319, 92)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(99, 13)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Nom du fichier CSV"
        '
        'TextBoxCSVName
        '
        Me.TextBoxCSVName.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TextBoxCSVName.Location = New System.Drawing.Point(322, 108)
        Me.TextBoxCSVName.Name = "TextBoxCSVName"
        Me.TextBoxCSVName.Size = New System.Drawing.Size(445, 20)
        Me.TextBoxCSVName.TabIndex = 17
        '
        'Start
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.TextBoxCSVName)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.CheckedListBoxPropertyToExport)
        Me.Controls.Add(Me.ButtonExecute)
        Me.Controls.Add(Me.FolderBrowserDialog)
        Me.Controls.Add(Me.TextBoxSelectedCSVDestinationFolder)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.CheckBoxRecursiveSelection)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.TreeViewProjectFolders)
        Me.Controls.Add(Me.TextBoxProjectName)
        Me.Name = "Start"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents TextBoxProjectName As TextBox
    Friend WithEvents TreeViewProjectFolders As TreeView
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBoxRecursiveSelection As CheckBox
    Friend WithEvents Label2 As Label
    Friend WithEvents FolderBrowserDialogCSVDestination As FolderBrowserDialog
    Friend WithEvents TextBoxSelectedCSVDestinationFolder As TextBox
    Friend WithEvents FolderBrowserDialog As Button
    Friend WithEvents ButtonExecute As Button
    Friend WithEvents CheckedListBoxPropertyToExport As CheckedListBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents TextBoxCSVName As TextBox
End Class
