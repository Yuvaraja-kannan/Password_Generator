using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Activities;
using System.ComponentModel;
using System.Security.Cryptography;

namespace String_Generator
{
    public class String_Builder : CodeActivity
    {

        [Category("Input")]
        [RequiredArgument]
        public InArgument<int> Len{ get; set; }

        [Category("Output")]
        public OutArgument<string> Result { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            var size = Len.Get(context);
            var charSet = "abcdefghijkmnpqrstuvwxyzABCDEFGHJKLMNPQRSTUVWXYZ23456789!@#$%&()";
            var chars = charSet.ToCharArray();
            var data = new byte[1];
            var crypto = new RNGCryptoServiceProvider();
            crypto.GetNonZeroBytes(data);
            data = new byte[size];
            crypto.GetNonZeroBytes(data);
            var result_out = new StringBuilder(size);
            foreach (var b in data)
            {
                result_out.Append(chars[b % (chars.Length)]);
            }
            
            string result_new = result_out.ToString();
            Result.Set(context, result_new);
        }


    }
}
