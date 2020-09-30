using GalaSoft.MvvmLight;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using JetBrains.Annotations;

namespace PopoutMenuTest.Utility
{
    public class ViewModel : ViewModelBase
    {
        /// <summary>
        /// This gives us the ReSharper option to transform an autoproperty into a property with change notification
        /// Also leverages .net 4.5 callermembername attribute
        /// </summary>
        /// <param name="property">name of the property</param>
        [NotifyPropertyChangedInvocator]

        public override void RaisePropertyChanged([CallerMemberName] string property = "")
        {
            base.RaisePropertyChanged(property);
        }
    }
}
