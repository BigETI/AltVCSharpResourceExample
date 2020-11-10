using AltV.Net;
using AltV.Net.Elements.Entities;
using AltVCSharpResourceExample.Entities;
using System;

/// <summary>
/// alt:V C♯ Resource Example factories namespace
/// </summary>
namespace AltVCSharpResourceExample.Factories
{
    /// <summary>
    /// Example checkpoint factory class
    /// </summary>
    internal class ExampleCheckpointFactory : IBaseObjectFactory<ICheckpoint>
    {
        /// <summary>
        /// Create checkpoint
        /// </summary>
        /// <param name="baseObjectPointer">Base object pointer</param>
        /// <returns>Checkpoint</returns>
        public ICheckpoint Create(IntPtr baseObjectPointer) => new ExampleCheckpointEntity(baseObjectPointer);
    }
}
