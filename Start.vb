Imports System.IO
Imports Microsoft.Win32

Public Class Start
    'Current project
    Dim CurrentProjectPdmId As PdmObjectId
    Dim CurrentProjectName As String
    'Folder
    Dim SelectedFolderPdmIdList As New List(Of PdmObjectId)
    Dim SelectedFolderNameList As New List(Of String)
    Dim FolderIdsToModify As New List(Of PdmObjectId)
    'CSV
    Dim SelectedCSVDestinationFolder As String
    Dim CSVDocumentName As String

    Private Sub Start_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'Coche automatique des item de CheckedListBoxPropertyToExport
        For i As Integer = 0 To CheckedListBoxPropertyToExport.Items.Count - 1
            CheckedListBoxPropertyToExport.SetItemChecked(i, True)
        Next

        'Connection à TopSolid
        Try
            TopSolidHost.Connect()  'Connection à TopSolid
            TopSolidDesignHost.Connect()    'Connection à TopSolid
        Catch ex As Exception
            MsgBox("Impossible de se connecter à TopSolid" + ex.Message)
            Exit Sub
        End Try

        Dim TSConnected As Boolean = TopSolidDesignHost.IsConnected
        If TSConnected = False Then MsgBox("Non connecté")

        Try
            CurrentProjectPdmId = TopSolidHost.Pdm.GetCurrentProject()   'Récupération ID projet
        Catch ex As Exception
            MsgBox("Echec de la récupération de l'id du projet courant" + ex.Message)
        End Try

        Try
            CurrentProjectName = TopSolidHost.Pdm.GetName(CurrentProjectPdmId)  'Récupération Nom projet
            TextBoxProjectName.Text = CurrentProjectName
        Catch ex As Exception
            MsgBox("Echec de la récupération de l'id du projet courant" + ex.Message)
        End Try

        'Récupération de la structure du projet
        Dim projects As New List(Of PdmObjectId)
        Dim rootFolderId As PdmObjectId
        Dim documentIds As New List(Of PdmObjectId)
        Dim folderIds As New List(Of PdmObjectId)
        Dim folderDictionary As New Dictionary(Of String, PdmObjectId)

        ' Récupération des sous-dossiers du dossier racine
        Try
            TopSolidHost.Pdm.GetConstituents(CurrentProjectPdmId, folderIds, documentIds)
        Catch ex As Exception
            MsgBox("Echec récupération des dossiers racine" + ex.Message)
        End Try


        ' Ajout des sous-dossiers du dossier racine au contrôle TreeView
        Try
            For Each folderId As PdmObjectId In folderIds
                Dim folderName As String = TopSolidHost.Pdm.GetName(folderId)
                'folderDictionary.Add(folderName, folderId) 'Problème déjà élément avec la même clé déjà ajouté
                Dim folderNode As New TreeNode(folderName)
                folderNode.Tag = folderId
                TreeViewProjectFolders.Nodes.Add(folderNode)
                'AddSubFolders(folderNode, folderId, CurrentProjectPdmId, folderDictionary) 'Problème déjà élément avec la même clé déjà ajouté
                AddSubFolders(folderNode, folderId, CurrentProjectPdmId) 'Problème déjà élément avec la même clé déjà ajouté
            Next
        Catch ex As Exception
            MsgBox("Echec récupération des sous dossiers" + vbNewLine + ex.Message)
        End Try

        '
        SelectedCSVDestinationFolder = GetDesktopFolderPath()
        TextBoxSelectedCSVDestinationFolder.Text = SelectedCSVDestinationFolder


    End Sub

    ' Fonction récursive pour ajouter les sous-dossiers à un noeud de TreeView
    'Private Sub AddSubFolders(parentNode As TreeNode, parentFolderId As PdmObjectId, ProjectId As PdmObjectId, folderDictionary As Dictionary(Of String, PdmObjectId)) 'Problème déjà élément avec la même clé déjà ajouté
    Private Sub AddSubFolders(parentNode As TreeNode, parentFolderId As PdmObjectId, ProjectId As PdmObjectId) 'Problème déjà élément avec la même clé déjà ajouté
        Dim subFolderIds As New List(Of PdmObjectId)
        Dim subDocumentIds As New List(Of PdmObjectId)

        TopSolidHost.Pdm.GetConstituents(parentFolderId, subFolderIds, subDocumentIds)

        For Each subFolderId As PdmObjectId In subFolderIds
            Dim subfolderName As String = TopSolidHost.Pdm.GetName(subFolderId)
            'folderDictionary.Add(subfolderName, subFolderId) 'Problème déjà élément avec la même clé déjà ajouté

            Dim subfolderNode As New TreeNode(subfolderName)
            subfolderNode.Tag = subFolderId ' Ajout de la propriété Tag pour stocker l'ID du dossier
            parentNode.Nodes.Add(subfolderNode)
            'AddSubFolders(subfolderNode, subFolderId, CurrentProjectPdmId, folderDictionary) 'Problème déjà élément avec la même clé déjà ajouté
            AddSubFolders(subfolderNode, subFolderId, CurrentProjectPdmId)
        Next
    End Sub

    Private Sub FolderBrowserDialog_Click(sender As Object, e As EventArgs) Handles FolderBrowserDialog.Click

        'Récupération du chemin du bureau
        Dim desktopPath As String = GetDesktopFolderPath()


        ' Configurer le FolderBrowserDialog
        With FolderBrowserDialogCSVDestination
            .Description = "Sélectionner un dossier de destination"
            ' Définir le dossier de départ (si nécessaire)
            .SelectedPath = desktopPath
            .ShowNewFolderButton = True ' Autoriser la création d'un nouveau dossier
        End With

        ' Afficher le FolderBrowserDialog et vérifier si l'utilisateur a appuyé sur OK
        If FolderBrowserDialogCSVDestination.ShowDialog() = DialogResult.OK Then
            ' Récupérer le chemin du dossier sélectionné
            SelectedCSVDestinationFolder = FolderBrowserDialogCSVDestination.SelectedPath
            TextBoxSelectedCSVDestinationFolder.Text = SelectedCSVDestinationFolder
        End If
    End Sub

    ' Fonction permettant de récupérer le chemin vers le bureau de l'utilisateur via les registres
    Private Function GetDesktopFolderPath() As String
        ' Clé du registre pour le chemin vers le bureau
        Dim registryKeyPath As String = "Software\Microsoft\Windows\CurrentVersion\Explorer\User Shell Folders"
        Dim registryValueName As String = "Desktop"

        ' Lire la valeur du registre
        Try
            Using registryKey As RegistryKey = Registry.CurrentUser.OpenSubKey(registryKeyPath)
                If registryKey IsNot Nothing Then
                    ' Lire la valeur du registre
                    Dim desktopPath As String = CStr(registryKey.GetValue(registryValueName))
                    Return desktopPath
                End If
            End Using
        Catch ex As Exception
            ' Gérer les erreurs liées à la lecture du registre
            MessageBox.Show($"Erreur lors de la lecture du registre : {ex.Message}")
        End Try

        ' Retourner une chaîne vide si le chemin n'a pas pu être récupéré
        Return String.Empty
    End Function

    'Fonction récursive pour récupérer des sous noeuds
    Private Sub CheckSubNodes(node As TreeNode)

        If node.Checked Then
            FolderIdsToModify.Add(DirectCast(node.Tag, PdmObjectId))
        End If
        For Each subNode As TreeNode In node.Nodes
            CheckSubNodes(subNode)
        Next

    End Sub


    ''' <summary>
    ''' Fonction récursive pour ajouter des sous documents
    ''' </summary>
    ''' <param name="parentFolderId">PdmObjectId du dossier parent</param>
    ''' <param name="documentPdmIds">List des documents à compléter</param>
    ''' <param name="SubFolder">Recherche ou non les sous dossiers</param>
    ''' <param name="SubDocument">Recherche ou non les sous documents</param>
    Private Sub AddSubDocuments(parentFolderId As PdmObjectId, ByRef documentPdmIds As List(Of PdmObjectId), SubFolder As Boolean, SubDocument As Boolean)
        Dim subFolderIds As New List(Of PdmObjectId)
        Dim subDocumentIds As New List(Of PdmObjectId)

        TopSolidHost.Pdm.GetConstituents(parentFolderId, subFolderIds, subDocumentIds)
        documentPdmIds.AddRange(subDocumentIds)

        If SubDocument Then
            For Each subDocumentId As PdmObjectId In subDocumentIds
                Dim subDocumentName As String = TopSolidHost.Pdm.GetName(subDocumentId)
                AddSubDocuments(subDocumentId, documentPdmIds, SubFolder, SubDocument)
            Next
        End If

        If SubFolder Then
            For Each subFolderId As PdmObjectId In subFolderIds
                AddSubDocuments(subFolderId, documentPdmIds, SubFolder, SubDocument)
            Next

        End If
    End Sub

    Private Sub ButtonExecute_Click(sender As Object, e As EventArgs) Handles ButtonExecute.Click
        For Each node As TreeNode In TreeViewProjectFolders.Nodes ' Récupération de tous les dossiers cochés
            CheckSubNodes(node)
        Next

        Dim DocumentIdsToModify As New List(Of DocumentId)
        Dim DocumentPdmIdsToModify As New List(Of PdmObjectId)

        'Remplacement de la méthode manuel ci après
        Try
            For Each FolderIdToModify As PdmObjectId In FolderIdsToModify

                AddSubDocuments(FolderIdToModify, DocumentPdmIdsToModify, CheckBoxRecursiveSelection.Checked, True)
            Next
        Catch ex As Exception
            MsgBox("Echec récupération des Pdm document Ids dans les dossiers sélectionnés" + ex.Message)
        End Try

        Try
            For Each DocumentPdmIdToModify In DocumentPdmIdsToModify
                DocumentIdsToModify.Add(TopSolidHost.Documents.GetDocument(DocumentPdmIdToModify))
            Next
        Catch ex As Exception
            MsgBox("Echec récupération des document Ids dans les dossiers sélectionnés" + ex.Message)
        End Try

        If DocumentIdsToModify.Count = 0 Then
            MsgBox("Aucun document à modifier")
            Exit Sub
        End If

        'Nombre de documents sélectionné
        Dim NumberOfDocumentSelected As Integer
        NumberOfDocumentSelected = DocumentIdsToModify.Count

        'Récupération du nombre de propriété sélectionné
        Dim NumberOfPropertySelected As Integer
        NumberOfPropertySelected = GetCheckedItemCount(CheckedListBoxPropertyToExport)

        ' Créer un tableau à deux dimensions (matrice)
        Dim DocumentsPropertiesToExportArray(NumberOfDocumentSelected, NumberOfPropertySelected - 1) As Object

        ' Exemple : initialisation du tableau avec des valeurs
        For documentIndex As Integer = 1 To NumberOfDocumentSelected - 1

            Dim ActiveDocumentId As DocumentId = DocumentIdsToModify.Item(documentIndex)
            Dim ActiveDocumentPdmObjectId As PdmObjectId = DocumentPdmIdsToModify.Item(documentIndex)

            Dim ActiveColumn As Integer = 0

            'Gestion Nom
            If CheckedListBoxPropertyToExport.GetItemChecked(0) Then
                If documentIndex = 1 Then
                    DocumentsPropertiesToExportArray(0, ActiveColumn) = "Nom"
                End If

                DocumentsPropertiesToExportArray(documentIndex, ActiveColumn) = TopSolidHost.Pdm.GetName(ActiveDocumentPdmObjectId)
                ActiveColumn += 1
            End If

            'Gestion Désignation
            If CheckedListBoxPropertyToExport.GetItemChecked(1) Then
                If documentIndex = 1 Then
                    DocumentsPropertiesToExportArray(0, ActiveColumn) = "Désignation"
                End If
                DocumentsPropertiesToExportArray(documentIndex, ActiveColumn) = TopSolidHost.Pdm.GetDescription(ActiveDocumentPdmObjectId)
                ActiveColumn += 1
            End If

            'Gestion Référence
            If CheckedListBoxPropertyToExport.GetItemChecked(2) Then
                If documentIndex = 1 Then
                    DocumentsPropertiesToExportArray(0, ActiveColumn) = "Référence"
                End If
                DocumentsPropertiesToExportArray(documentIndex, ActiveColumn) = TopSolidHost.Pdm.GetPartNumber(ActiveDocumentPdmObjectId)
                ActiveColumn += 1
            End If

            'Gestion Fabricant
            If CheckedListBoxPropertyToExport.GetItemChecked(3) Then
                If documentIndex = 1 Then
                    DocumentsPropertiesToExportArray(0, ActiveColumn) = "Fabricant"
                End If
                DocumentsPropertiesToExportArray(documentIndex, ActiveColumn) = TopSolidHost.Pdm.GetManufacturer(ActiveDocumentPdmObjectId)
                ActiveColumn += 1
            End If

            'Gestion Référence Fabricant
            If CheckedListBoxPropertyToExport.GetItemChecked(4) Then
                If documentIndex = 1 Then
                    DocumentsPropertiesToExportArray(0, ActiveColumn) = "Référence fabricant"
                End If
                DocumentsPropertiesToExportArray(documentIndex, ActiveColumn) = TopSolidHost.Pdm.GetManufacturerPartNumber(ActiveDocumentPdmObjectId)
                ActiveColumn = +1
            End If

            'Gestion Type de document
            If CheckedListBoxPropertyToExport.GetItemChecked(5) Then
                If documentIndex = 1 Then
                    DocumentsPropertiesToExportArray(0, ActiveColumn) = "Type de document"
                End If
                TopSolidHost.Pdm.GetType(ActiveDocumentPdmObjectId, DocumentsPropertiesToExportArray(documentIndex, ActiveColumn))
                ActiveColumn = +1
            End If

        Next


        'Export du CSV

        ' Chemin de destination et nom du fichier CSV
        Dim csvFilePath As String = Path.Combine(SelectedCSVDestinationFolder, $"{CSVDocumentName}.csv")

        ' Écrire les données dans le fichier CSV
        Using writer As New StreamWriter(csvFilePath, False, System.Text.Encoding.UTF8)
            For i As Integer = 0 To NumberOfDocumentSelected - 1
                For j As Integer = 0 To NumberOfPropertySelected - 1
                    ' Écrire la valeur dans le fichier avec le séparateur ;
                    writer.Write(DocumentsPropertiesToExportArray(i, j))
                    ' Ajouter le séparateur si ce n'est pas la dernière colonne
                    If j < DocumentsPropertiesToExportArray.GetLength(1) - 1 Then
                        writer.Write(";")
                    End If
                Next
                ' Passer à la ligne suivante
                writer.WriteLine()
            Next
        End Using

        ' Ouvrir le document résultant
        Process.Start(csvFilePath)

    End Sub

    Private Function GetCheckedItemCount(checkedListBox As CheckedListBox) As Integer
        Dim count As Integer = 0

        For Each itemIndex As Integer In checkedListBox.CheckedIndices
            ' L'élément à l'index itemIndex est coché
            count += 1
        Next

        ' Vous pouvez également utiliser la propriété CheckedItems pour obtenir les éléments cochés
        ' For Each checkedItem As Object In checkedListBox.CheckedItems
        '     count += 1
        ' Next

        Return count
    End Function

    Private Sub TextBoxCSVName_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCSVName.TextChanged
        CSVDocumentName = TextBoxCSVName.Text
    End Sub


End Class
