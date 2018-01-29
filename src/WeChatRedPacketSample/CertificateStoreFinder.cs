using System;
using System.Security.Cryptography.X509Certificates;

namespace WeChatRedPacketSample
{
    public class CertificateStoreFinder : ICertificateFinder
    {
        string m_SubjectDistinguishedName;
        string m_password;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subjectDistinguishedName"></param>
        /// <param name="password">安装证书时设置的密码</param>
        public CertificateStoreFinder(string subjectDistinguishedName,string password)
        {
            if (subjectDistinguishedName == null)
                throw new ArgumentNullException("subjectDistinguishedName");

            m_SubjectDistinguishedName = subjectDistinguishedName;
            m_password = password;
        }

        public X509Certificate2 Find()
        {
            var cert = new System.Security.Cryptography.X509Certificates.X509Certificate2(m_SubjectDistinguishedName, m_password, X509KeyStorageFlags.MachineKeySet);
            return cert;
        }
    }
}
