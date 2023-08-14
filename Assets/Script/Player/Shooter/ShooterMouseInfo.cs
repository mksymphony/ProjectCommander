using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ShooterMouseInfo
{
    #region -Player-

    public class PlayerSettingModel
    {
        [Header("View Setting")]
        protected float ViewXSensitivity;
        protected float ViewYSensitivity;

        protected bool ViewXInverted;
        protected bool ViewYInberted;
    }

    #endregion
}
