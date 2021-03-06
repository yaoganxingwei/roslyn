﻿' Licensed to the .NET Foundation under one or more agreements.
' The .NET Foundation licenses this file to you under the MIT license.
' See the LICENSE file in the project root for more information.

Imports System.Threading
Imports Microsoft.CodeAnalysis.Options
Imports Microsoft.CodeAnalysis.PooledObjects
Imports Microsoft.CodeAnalysis.Structure
Imports Microsoft.CodeAnalysis.VisualBasic.Syntax

Namespace Microsoft.CodeAnalysis.VisualBasic.Structure
    Friend Class ExternalMethodDeclarationStructureProvider
        Inherits AbstractSyntaxNodeStructureProvider(Of DeclareStatementSyntax)

        Protected Overrides Sub CollectBlockSpans(externalMethodDeclaration As DeclareStatementSyntax,
                                                  spans As ArrayBuilder(Of BlockSpan),
                                                  isMetadataAsSource As Boolean,
                                                  options As OptionSet,
                                                  cancellationToken As CancellationToken)
            CollectCommentsRegions(externalMethodDeclaration, spans, isMetadataAsSource)
        End Sub
    End Class
End Namespace
