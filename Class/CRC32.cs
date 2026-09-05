using System;
using System.IO;

public class CRC32
{
    private readonly uint[] table;

    public CRC32()
    {
        const uint polynomial = 0xedb88320;
        table = new uint[256];
        for (uint i = 0; i < 256; i++)
        {
            uint crc = i;
            for (uint j = 8; j > 0; j--)
            {
                if ((crc & 1) == 1)
                    crc = (crc >> 1) ^ polynomial;
                else
                    crc >>= 1;
            }
            table[i] = crc;
        }
    }

    public uint ComputeChecksum(byte[] bytes)
    {
        uint crc = 0xffffffff;
        foreach (byte b in bytes)
        {
            byte tableIndex = (byte)((crc ^ b) & 0xff);
            crc = (crc >> 8) ^ table[tableIndex];
        }
        return ~crc;
    }

    public uint ComputeChecksum(Stream stream)
    {
        uint crc = 0xffffffff;
        int b;
        while ((b = stream.ReadByte()) != -1)
        {
            byte tableIndex = (byte)((crc ^ b) & 0xff);
            crc = (crc >> 8) ^ table[tableIndex];
        }
        return ~crc;
    }
}
