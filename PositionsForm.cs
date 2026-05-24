namespace OrdreMission;

public partial class PositionsForm : Form
{
    private readonly AppSettings _cfg;

    public PositionsForm(AppSettings cfg)
    {
        _cfg = cfg;
        InitializeComponent();
        LoadValues();
    }

    private void LoadValues()
    {
        NudPeageX.Value  = (decimal)_cfg.Peage.X;       NudPeageY.Value  = (decimal)_cfg.Peage.Y;       NudPeageSz.Value  = (decimal)_cfg.Peage.Hauteur;       NudPeageLg.Value  = (decimal)_cfg.Peage.Largeur;
        NudKmX.Value     = (decimal)_cfg.NbKm.X;        NudKmY.Value     = (decimal)_cfg.NbKm.Y;        NudKmSz.Value     = (decimal)_cfg.NbKm.Hauteur;        NudKmLg.Value     = (decimal)_cfg.NbKm.Largeur;
        NudTfX.Value     = (decimal)_cfg.TotalFrais.X;  NudTfY.Value     = (decimal)_cfg.TotalFrais.Y;  NudTfSz.Value     = (decimal)_cfg.TotalFrais.Hauteur;  NudTfLg.Value     = (decimal)_cfg.TotalFrais.Largeur;

        NudRapAccX.Value = (decimal)_cfg.RapportAccueil.X;    NudRapAccY.Value = (decimal)_cfg.RapportAccueil.Y;    NudRapAccSz.Value = (decimal)_cfg.RapportAccueil.Hauteur;    NudRapAccLg.Value = (decimal)_cfg.RapportAccueil.Largeur;
        NudRapEqX.Value  = (decimal)_cfg.RapportEquipement.X; NudRapEqY.Value  = (decimal)_cfg.RapportEquipement.Y; NudRapEqSz.Value  = (decimal)_cfg.RapportEquipement.Hauteur;  NudRapEqLg.Value  = (decimal)_cfg.RapportEquipement.Largeur;

        NudCompOppX.Value   = (decimal)_cfg.CompOpposant.X;    NudCompOppY.Value   = (decimal)_cfg.CompOpposant.Y;    NudCompOppHt.Value   = (decimal)_cfg.CompOpposant.Hauteur;    NudCompOppLg.Value   = (decimal)_cfg.CompOpposant.Largeur;
        NudCompDateX.Value  = (decimal)_cfg.CompDate.X;        NudCompDateY.Value  = (decimal)_cfg.CompDate.Y;        NudCompDateHt.Value  = (decimal)_cfg.CompDate.Hauteur;        NudCompDateLg.Value  = (decimal)_cfg.CompDate.Largeur;
        NudCompHeureX.Value = (decimal)_cfg.CompHeure.X;       NudCompHeureY.Value = (decimal)_cfg.CompHeure.Y;       NudCompHeureHt.Value = (decimal)_cfg.CompHeure.Hauteur;       NudCompHeureLg.Value = (decimal)_cfg.CompHeure.Largeur;
        NudCompAddrX.Value  = (decimal)_cfg.CompAdresse.X;     NudCompAddrY.Value  = (decimal)_cfg.CompAdresse.Y;     NudCompAddrHt.Value  = (decimal)_cfg.CompAdresse.Hauteur;     NudCompAddrLg.Value  = (decimal)_cfg.CompAdresse.Largeur;
        NudCompRespX.Value  = (decimal)_cfg.CompResponsable.X; NudCompRespY.Value  = (decimal)_cfg.CompResponsable.Y; NudCompRespHt.Value  = (decimal)_cfg.CompResponsable.Hauteur; NudCompRespLg.Value  = (decimal)_cfg.CompResponsable.Largeur;

        NudSigX.Value = (decimal)_cfg.SigX; NudSigY.Value = (decimal)_cfg.SigY;
        NudSigW.Value = (decimal)_cfg.SigW; NudSigH.Value = (decimal)_cfg.SigH;
        NudPage.Value = _cfg.Page;
        ChkRectVisibles.Checked = _cfg.RectanglesVisibles;
    }

    private void BtnOk_Click(object? sender, EventArgs e)
    {
        _cfg.Peage      = new FieldPos { X = (float)NudPeageX.Value, Y = (float)NudPeageY.Value, Hauteur = (float)NudPeageSz.Value, Largeur = (float)NudPeageLg.Value };
        _cfg.NbKm       = new FieldPos { X = (float)NudKmX.Value,    Y = (float)NudKmY.Value,    Hauteur = (float)NudKmSz.Value,    Largeur = (float)NudKmLg.Value    };
        _cfg.TotalFrais = new FieldPos { X = (float)NudTfX.Value,    Y = (float)NudTfY.Value,    Hauteur = (float)NudTfSz.Value,    Largeur = (float)NudTfLg.Value    };

        _cfg.RapportAccueil    = new FieldPos { X = (float)NudRapAccX.Value, Y = (float)NudRapAccY.Value, Hauteur = (float)NudRapAccSz.Value, Largeur = (float)NudRapAccLg.Value };
        _cfg.RapportEquipement = new FieldPos { X = (float)NudRapEqX.Value,  Y = (float)NudRapEqY.Value,  Hauteur = (float)NudRapEqSz.Value,  Largeur = (float)NudRapEqLg.Value  };

        _cfg.CompOpposant    = new FieldPos { X = (float)NudCompOppX.Value,   Y = (float)NudCompOppY.Value,   Hauteur = (float)NudCompOppHt.Value,   Largeur = (float)NudCompOppLg.Value   };
        _cfg.CompDate        = new FieldPos { X = (float)NudCompDateX.Value,  Y = (float)NudCompDateY.Value,  Hauteur = (float)NudCompDateHt.Value,  Largeur = (float)NudCompDateLg.Value  };
        _cfg.CompHeure       = new FieldPos { X = (float)NudCompHeureX.Value, Y = (float)NudCompHeureY.Value, Hauteur = (float)NudCompHeureHt.Value, Largeur = (float)NudCompHeureLg.Value };
        _cfg.CompAdresse     = new FieldPos { X = (float)NudCompAddrX.Value,  Y = (float)NudCompAddrY.Value,  Hauteur = (float)NudCompAddrHt.Value,  Largeur = (float)NudCompAddrLg.Value  };
        _cfg.CompResponsable = new FieldPos { X = (float)NudCompRespX.Value,  Y = (float)NudCompRespY.Value,  Hauteur = (float)NudCompRespHt.Value,  Largeur = (float)NudCompRespLg.Value  };

        _cfg.SigX = (float)NudSigX.Value; _cfg.SigY = (float)NudSigY.Value;
        _cfg.SigW = (float)NudSigW.Value; _cfg.SigH = (float)NudSigH.Value;
        _cfg.Page               = (int)NudPage.Value;
        _cfg.RectanglesVisibles = ChkRectVisibles.Checked;
        _cfg.Save();
    }
}
