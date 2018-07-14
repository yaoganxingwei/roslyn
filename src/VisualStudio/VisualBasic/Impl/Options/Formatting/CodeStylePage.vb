﻿' Copyright (c) Microsoft.  All Rights Reserved.  Licensed under the Apache License, Version 2.0.  See License.txt in the project root for license information.

Imports System.Runtime.InteropServices
Imports System.Text
Imports Microsoft.CodeAnalysis
Imports Microsoft.CodeAnalysis.CodeStyle
Imports Microsoft.CodeAnalysis.Editing
Imports Microsoft.CodeAnalysis.Formatting
Imports Microsoft.CodeAnalysis.Options
Imports Microsoft.CodeAnalysis.VisualBasic.CodeStyle
Imports Microsoft.VisualStudio.LanguageServices.Implementation.Options

Namespace Microsoft.VisualStudio.LanguageServices.VisualBasic.Options.Formatting
    <Guid(Guids.VisualBasicOptionPageCodeStyleIdString)>
    Friend Class CodeStylePage
        Inherits AbstractOptionPage

        Protected Overrides Function CreateOptionPage(serviceProvider As IServiceProvider) As AbstractOptionPageControl
            Return New GridOptionPreviewControl(serviceProvider, Function(o, s) New StyleViewModel(o, s), AddressOf GetCurrentEditorConfigOptionsVB, LanguageNames.VisualBasic)
        End Function

        Friend Shared Sub GetCurrentEditorConfigOptionsVB(ByVal optionSet As OptionSet, ByVal editorconfig As StringBuilder)
            editorconfig.AppendLine()
            editorconfig.AppendLine("###############################")
            editorconfig.AppendLine("# VB Coding Conventions       #")
            editorconfig.AppendLine("###############################")

            editorconfig.AppendLine("# Modifier preferences")
            ' visual_basic_preferred_modifier_order
            VBCodeStyleOptions_GenerateEditorconfig(optionSet, VisualBasicCodeStyleOptions.PreferredModifierOrder, editorconfig)
        End Sub

        Private Shared Sub VBCodeStyleOptions_GenerateEditorconfig(ByVal optionSet As OptionSet, ByVal [option] As [Option](Of CodeStyleOption(Of String)), ByVal editorconfig As StringBuilder)
            editorconfig.Append((CType([option].StorageLocations.OfType(Of IEditorConfigStorageLocation).SingleOrDefault(), EditorConfigStorageLocation(Of CodeStyleOption(Of String)))).KeyName)
            editorconfig.Append(" = ")

            Dim curSetting = optionSet.GetOption([option])
            editorconfig.AppendLine(curSetting.Value + ":" + curSetting.Notification.ToString().ToLower())
        End Sub
    End Class
End Namespace
