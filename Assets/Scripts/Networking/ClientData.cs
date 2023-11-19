using System;

// Class lưu in4 của player ở mức độ Client-server (k phải data trong game)
[Serializable]
public class ClientData
{
    public ulong clientId;
    public int characterId = -1;

    public ClientData(ulong clientId)
    {
        this.clientId = clientId;
    }
}
