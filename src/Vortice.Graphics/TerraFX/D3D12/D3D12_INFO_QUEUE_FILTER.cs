// Copyright � Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/d3d12sdklayers.h in the Windows SDK for Windows 10.0.22000.0
// Original source is Copyright � Microsoft. All rights reserved.

namespace TerraFX.Interop.DirectX;

internal unsafe partial struct D3D12_INFO_QUEUE_FILTER_DESC
{
    public uint NumCategories;
    public D3D12_MESSAGE_CATEGORY* pCategoryList;

    /// <include file='D3D12_INFO_QUEUE_FILTER_DESC.xml' path='doc/member[@name="D3D12_INFO_QUEUE_FILTER_DESC.NumSeverities"]/*' />
    public uint NumSeverities;

    /// <include file='D3D12_INFO_QUEUE_FILTER_DESC.xml' path='doc/member[@name="D3D12_INFO_QUEUE_FILTER_DESC.pSeverityList"]/*' />
    public D3D12_MESSAGE_SEVERITY* pSeverityList;

    /// <include file='D3D12_INFO_QUEUE_FILTER_DESC.xml' path='doc/member[@name="D3D12_INFO_QUEUE_FILTER_DESC.NumIDs"]/*' />
    public uint NumIDs;

    /// <include file='D3D12_INFO_QUEUE_FILTER_DESC.xml' path='doc/member[@name="D3D12_INFO_QUEUE_FILTER_DESC.pIDList"]/*' />
    public D3D12_MESSAGE_ID* pIDList;
}

internal partial struct D3D12_INFO_QUEUE_FILTER
{
    /// <include file='D3D12_INFO_QUEUE_FILTER.xml' path='doc/member[@name="D3D12_INFO_QUEUE_FILTER.AllowList"]/*' />
    public D3D12_INFO_QUEUE_FILTER_DESC AllowList;

    /// <include file='D3D12_INFO_QUEUE_FILTER.xml' path='doc/member[@name="D3D12_INFO_QUEUE_FILTER.DenyList"]/*' />
    public D3D12_INFO_QUEUE_FILTER_DESC DenyList;
}
