using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kae.DomainModel.CSharp.Utilitiy.Tools.WpfAppDomainModelViewer
{
    public interface DomainModelViewer
    {
        void RegisterInstance(string classKeyLetter, string nameOfIdentities, string identities);
        void UnregisterInstance(string classKeyLetter, string identities);
        void ShowInstance(string classKeyLetter, string identities);
    }
}
