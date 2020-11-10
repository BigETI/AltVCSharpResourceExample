using AltV.Net.Elements.Entities;
using System;

/// <summary>
/// alt:V C♯ Resource Example entities namespace
/// </summary>
namespace AltVCSharpResourceExample.Entities
{
    /// <summary>
    /// Example checkpoint entity class
    /// </summary>
    internal class ExampleCheckpointEntity : Checkpoint, IExampleCheckpointEntity
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="nativePointer">Native pointer</param>
        public ExampleCheckpointEntity(IntPtr nativePointer) : base(nativePointer)
        {
            // ...
        }
    }
}
