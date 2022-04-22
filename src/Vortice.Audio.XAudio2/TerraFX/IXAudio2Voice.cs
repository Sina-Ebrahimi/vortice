/// Copyright © Tanner Gooding and Contributors. Licensed under the MIT License (MIT). See License.md in the repository root for more information.

// Ported from um/xaudio2.h in the Windows SDK for Windows 10.0.22000.0
// Original source is Copyright © Microsoft. All rights reserved.

using System.Runtime.CompilerServices;
using TerraFX.Interop.Windows;

namespace TerraFX.Interop.DirectX;

internal unsafe partial struct IXAudio2Voice : IXAudio2Voice.Interface
{
    public void** lpVtbl;

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(0)]
    public void GetVoiceDetails(XAUDIO2_VOICE_DETAILS* pVoiceDetails)
    {
        ((delegate* unmanaged<IXAudio2Voice*, XAUDIO2_VOICE_DETAILS*, void>)(lpVtbl[0]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), pVoiceDetails);
    }

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //[VtblIndex(1)]
    //public HRESULT SetOutputVoices([NativeTypeName("const XAUDIO2_VOICE_SENDS *")] XAUDIO2_VOICE_SENDS* pSendList)
    //{
    //    return ((delegate* unmanaged<IXAudio2Voice*, XAUDIO2_VOICE_SENDS*, int>)(lpVtbl[1]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), pSendList);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //[VtblIndex(2)]
    //public HRESULT SetEffectChain([NativeTypeName("const XAUDIO2_EFFECT_CHAIN *")] XAUDIO2_EFFECT_CHAIN* pEffectChain)
    //{
    //    return ((delegate* unmanaged<IXAudio2Voice*, XAUDIO2_EFFECT_CHAIN*, int>)(lpVtbl[2]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), pEffectChain);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //[VtblIndex(3)]
    //public HRESULT EnableEffect([NativeTypeName("UINT32")] uint EffectIndex, [NativeTypeName("UINT32")] uint OperationSet = 0)
    //{
    //    return ((delegate* unmanaged<IXAudio2Voice*, uint, uint, int>)(lpVtbl[3]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), EffectIndex, OperationSet);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //[VtblIndex(4)]
    //public HRESULT DisableEffect([NativeTypeName("UINT32")] uint EffectIndex, [NativeTypeName("UINT32")] uint OperationSet = 0)
    //{
    //    return ((delegate* unmanaged<IXAudio2Voice*, uint, uint, int>)(lpVtbl[4]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), EffectIndex, OperationSet);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //[VtblIndex(5)]
    //public void GetEffectState([NativeTypeName("UINT32")] uint EffectIndex, BOOL* pEnabled)
    //{
    //    ((delegate* unmanaged<IXAudio2Voice*, uint, BOOL*, void>)(lpVtbl[5]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), EffectIndex, pEnabled);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //[VtblIndex(6)]
    //public HRESULT SetEffectParameters([NativeTypeName("UINT32")] uint EffectIndex, [NativeTypeName("const void *")] void* pParameters, [NativeTypeName("UINT32")] uint ParametersByteSize, [NativeTypeName("UINT32")] uint OperationSet = 0)
    //{
    //    return ((delegate* unmanaged<IXAudio2Voice*, uint, void*, uint, uint, int>)(lpVtbl[6]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), EffectIndex, pParameters, ParametersByteSize, OperationSet);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //[VtblIndex(7)]
    //public HRESULT GetEffectParameters([NativeTypeName("UINT32")] uint EffectIndex, void* pParameters, [NativeTypeName("UINT32")] uint ParametersByteSize)
    //{
    //    return ((delegate* unmanaged<IXAudio2Voice*, uint, void*, uint, int>)(lpVtbl[7]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), EffectIndex, pParameters, ParametersByteSize);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //[VtblIndex(8)]
    //public HRESULT SetFilterParameters([NativeTypeName("const XAUDIO2_FILTER_PARAMETERS *")] XAUDIO2_FILTER_PARAMETERS* pParameters, [NativeTypeName("UINT32")] uint OperationSet = 0)
    //{
    //    return ((delegate* unmanaged<IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, uint, int>)(lpVtbl[8]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), pParameters, OperationSet);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //[VtblIndex(9)]
    //public void GetFilterParameters(XAUDIO2_FILTER_PARAMETERS* pParameters)
    //{
    //    ((delegate* unmanaged<IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, void>)(lpVtbl[9]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), pParameters);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //[VtblIndex(10)]
    //public HRESULT SetOutputFilterParameters(IXAudio2Voice* pDestinationVoice, [NativeTypeName("const XAUDIO2_FILTER_PARAMETERS *")] XAUDIO2_FILTER_PARAMETERS* pParameters, [NativeTypeName("UINT32")] uint OperationSet = 0)
    //{
    //    return ((delegate* unmanaged<IXAudio2Voice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, uint, int>)(lpVtbl[10]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), pDestinationVoice, pParameters, OperationSet);
    //}

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //[VtblIndex(11)]
    //public void GetOutputFilterParameters(IXAudio2Voice* pDestinationVoice, XAUDIO2_FILTER_PARAMETERS* pParameters)
    //{
    //    ((delegate* unmanaged<IXAudio2Voice*, IXAudio2Voice*, XAUDIO2_FILTER_PARAMETERS*, void>)(lpVtbl[11]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), pDestinationVoice, pParameters);
    //}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(12)]
    public HRESULT SetVolume(float Volume, [NativeTypeName("UINT32")] uint OperationSet = 0)
    {
        return ((delegate* unmanaged<IXAudio2Voice*, float, uint, int>)(lpVtbl[12]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), Volume, OperationSet);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(13)]
    public void GetVolume(float* pVolume)
    {
        ((delegate* unmanaged<IXAudio2Voice*, float*, void>)(lpVtbl[13]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), pVolume);
    }

    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //[VtblIndex(14)]
    //public HRESULT SetChannelVolumes([NativeTypeName("UINT32")] uint Channels, [NativeTypeName("const float *")] float* pVolumes, [NativeTypeName("UINT32")] uint OperationSet = 0)
    //{
    //    return ((delegate* unmanaged<IXAudio2Voice*, uint, float*, uint, int>)(lpVtbl[14]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), Channels, pVolumes, OperationSet);
    //}

    ///// <include file='IXAudio2Voice.xml' path='doc/member[@name="IXAudio2Voice.GetChannelVolumes"]/*' />
    //[MethodImpl(MethodImplOptions.AggressiveInlining)]
    //[VtblIndex(15)]
    //public void GetChannelVolumes([NativeTypeName("UINT32")] uint Channels, float* pVolumes)
    //{
    //    ((delegate* unmanaged<IXAudio2Voice*, uint, float*, void>)(lpVtbl[15]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), Channels, pVolumes);
    //}

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(16)]
    public HRESULT SetOutputMatrix(IXAudio2Voice* pDestinationVoice, [NativeTypeName("UINT32")] uint SourceChannels, [NativeTypeName("UINT32")] uint DestinationChannels, [NativeTypeName("const float *")] float* pLevelMatrix, [NativeTypeName("UINT32")] uint OperationSet = 0)
    {
        return ((delegate* unmanaged<IXAudio2Voice*, IXAudio2Voice*, uint, uint, float*, uint, int>)(lpVtbl[16]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), pDestinationVoice, SourceChannels, DestinationChannels, pLevelMatrix, OperationSet);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(17)]
    public void GetOutputMatrix(IXAudio2Voice* pDestinationVoice, [NativeTypeName("UINT32")] uint SourceChannels, [NativeTypeName("UINT32")] uint DestinationChannels, float* pLevelMatrix)
    {
        ((delegate* unmanaged<IXAudio2Voice*, IXAudio2Voice*, uint, uint, float*, void>)(lpVtbl[17]))((IXAudio2Voice*)Unsafe.AsPointer(ref this), pDestinationVoice, SourceChannels, DestinationChannels, pLevelMatrix);
    }

    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    [VtblIndex(18)]
    public void DestroyVoice()
    {
        ((delegate* unmanaged<IXAudio2Voice*, void>)(lpVtbl[18]))((IXAudio2Voice*)Unsafe.AsPointer(ref this));
    }

    public interface Interface
    {
        [VtblIndex(0)]
        void GetVoiceDetails(XAUDIO2_VOICE_DETAILS* pVoiceDetails);

        //[VtblIndex(1)]
        //HRESULT SetOutputVoices([NativeTypeName("const XAUDIO2_VOICE_SENDS *")] XAUDIO2_VOICE_SENDS* pSendList);

        //[VtblIndex(2)]
        //HRESULT SetEffectChain([NativeTypeName("const XAUDIO2_EFFECT_CHAIN *")] XAUDIO2_EFFECT_CHAIN* pEffectChain);

        //[VtblIndex(3)]
        //HRESULT EnableEffect([NativeTypeName("UINT32")] uint EffectIndex, [NativeTypeName("UINT32")] uint OperationSet = 0);

        //[VtblIndex(4)]
        //HRESULT DisableEffect([NativeTypeName("UINT32")] uint EffectIndex, [NativeTypeName("UINT32")] uint OperationSet = 0);

        //[VtblIndex(5)]
        //void GetEffectState([NativeTypeName("UINT32")] uint EffectIndex, BOOL* pEnabled);

        //[VtblIndex(6)]
        //HRESULT SetEffectParameters([NativeTypeName("UINT32")] uint EffectIndex, [NativeTypeName("const void *")] void* pParameters, [NativeTypeName("UINT32")] uint ParametersByteSize, [NativeTypeName("UINT32")] uint OperationSet = 0);

        //[VtblIndex(7)]
        //HRESULT GetEffectParameters([NativeTypeName("UINT32")] uint EffectIndex, void* pParameters, [NativeTypeName("UINT32")] uint ParametersByteSize);

        //[VtblIndex(8)]
        //HRESULT SetFilterParameters([NativeTypeName("const XAUDIO2_FILTER_PARAMETERS *")] XAUDIO2_FILTER_PARAMETERS* pParameters, [NativeTypeName("UINT32")] uint OperationSet = 0);

        //[VtblIndex(9)]
        //void GetFilterParameters(XAUDIO2_FILTER_PARAMETERS* pParameters);

        //[VtblIndex(10)]
        //HRESULT SetOutputFilterParameters(IXAudio2Voice* pDestinationVoice, [NativeTypeName("const XAUDIO2_FILTER_PARAMETERS *")] XAUDIO2_FILTER_PARAMETERS* pParameters, [NativeTypeName("UINT32")] uint OperationSet = 0);

        //[VtblIndex(11)]
        //void GetOutputFilterParameters(IXAudio2Voice* pDestinationVoice, XAUDIO2_FILTER_PARAMETERS* pParameters);

        [VtblIndex(12)]
        HRESULT SetVolume(float Volume, [NativeTypeName("UINT32")] uint OperationSet = 0);

        [VtblIndex(13)]
        void GetVolume(float* pVolume);

        //[VtblIndex(14)]
        //HRESULT SetChannelVolumes([NativeTypeName("UINT32")] uint Channels, [NativeTypeName("const float *")] float* pVolumes, [NativeTypeName("UINT32")] uint OperationSet = 0);

        //[VtblIndex(15)]
        //void GetChannelVolumes([NativeTypeName("UINT32")] uint Channels, float* pVolumes);

        [VtblIndex(16)]
        HRESULT SetOutputMatrix(IXAudio2Voice* pDestinationVoice, [NativeTypeName("UINT32")] uint SourceChannels, [NativeTypeName("UINT32")] uint DestinationChannels, [NativeTypeName("const float *")] float* pLevelMatrix, [NativeTypeName("UINT32")] uint OperationSet = 0);

        [VtblIndex(17)]
        void GetOutputMatrix(IXAudio2Voice* pDestinationVoice, [NativeTypeName("UINT32")] uint SourceChannels, [NativeTypeName("UINT32")] uint DestinationChannels, float* pLevelMatrix);

        [VtblIndex(18)]
        void DestroyVoice();
    }
}
