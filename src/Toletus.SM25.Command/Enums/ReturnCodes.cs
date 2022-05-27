﻿namespace Toletus.SM25.Command.Enums
{
    public enum ReturnCodes
    {
        ERR_SUCCESS = 0x00,
        ERR_FAIL = 0x01,
        ERR_VERIFY = 0x11,
        ERR_IDENTIFY = 0x12,
        ERR_TMPL_EMPTY = 0x13,
        ERR_TMPL_NOT_EMPTY = 0x14,
        ERR_ALL_TMPL_EMPTY = 0x15,
        ERR_EMPTY_ID_NOEXIST = 0x16,
        ERR_BROKEN_ID_NOEXIST = 0x17,
        ERR_INVALID_TMPL_DATA = 0x18,
        ERR_DUPLICATION_ID = 0x19,
        ERR_BAD_QUALITY = 0x21,
        ERR_TIME_OUT = 0x23,
        ERR_NOT_AUTHORIZED = 0x24,
        ERR_GENERALIZE = 0x30,
        ERR_FP_CANCEL = 0x41,
        ERR_INTERNAL = 0x50,
        ERR_MEMORY = 0x51,
        ERR_EXCEPTION = 0x52,
        ERR_INVALID_TMPL_NO = 0x60,
        ERR_INVALID_SEC_VAL = 0x61,
        ERR_INVALID_TIME_OUT = 0x62,
        ERR_INVALID_BAUDRATE = 0x63,
        ERR_DEVICE_ID_EMPTY = 0x64,
        ERR_INVALID_DUP_VAL = 0x65,
        ERR_INVALID_PARAM = 0x70,
        ERR_NO_RELEASE = 0x71,
        ERR_UNDEFINED = 0x99
    }
}
