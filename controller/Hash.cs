using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ponchland.controller
{
    class Hash
    {
        public string sum;

        public Hash(string str)
        {
            this.sum = k_sum(str);
        }

        private string k_sum(string str)
        {
            if (str.Length % 2 != 0)
            {
                str += 's';
            }
            for (int i = 0; i < str.Length; i += 2)
            {
                int mult = str[i] * str[i + 1];
                int div = str[i] / str[i + 1];

                sum += recevingExistCodes(mult);
                sum += recevingExistCodes(div);
            }
            return sum;
        }

        private int recevingExistCodes(int x)
        {
            x += 256;
            while (!(((x <= 57) && (x >= 48)) || ((x <= 90) && (x >= 65)) || ((x <= 122) && (x >= 97))))
            {
                if (x < 48) x += 24;
                else x -= 47;
            }
            return x;
        }
    }
}

