namespace OrdreMission;

public partial class PositionsForm : Form
{
    private readonly AppSettings _cfg;

    public PositionsForm(AppSettings cfg)
    {
        _cfg = cfg;
        InitializeComponent();
        AppImages.AppliquerSauvegarde(BtnOk);
        AppImages.AppliquerAnnuler(BtnCancel);
        LoadValues();
    }

    private void LoadValues()
    {
        NudCompOppX.Value = (decimal)_cfg.Opposant.X; NudCompOppY.Value = (decimal)_cfg.Opposant.Y; NudCompOppHt.Value = (decimal)_cfg.Opposant.Hauteur; NudCompOppLg.Value = (decimal)_cfg.Opposant.Largeur;
        NudCompDateX.Value = (decimal)_cfg.Date.X; NudCompDateY.Value = (decimal)_cfg.Date.Y; NudCompDateHt.Value = (decimal)_cfg.Date.Hauteur; NudCompDateLg.Value = (decimal)_cfg.Date.Largeur;
        NudCompHeureX.Value = (decimal)_cfg.Heure.X; NudCompHeureY.Value = (decimal)_cfg.Heure.Y; NudCompHeureHt.Value = (decimal)_cfg.Heure.Hauteur; NudCompHeureLg.Value = (decimal)_cfg.Heure.Largeur;
        NudCompAddrX.Value = (decimal)_cfg.Adresse.X; NudCompAddrY.Value = (decimal)_cfg.Adresse.Y; NudCompAddrHt.Value = (decimal)_cfg.Adresse.Hauteur; NudCompAddrLg.Value = (decimal)_cfg.Adresse.Largeur;

        NudPeageX.Value  = (decimal)_cfg.Peage.X;       NudPeageY.Value  = (decimal)_cfg.Peage.Y;       NudPeageSz.Value  = (decimal)_cfg.Peage.Hauteur;       NudPeageLg.Value  = (decimal)_cfg.Peage.Largeur;
        NudKmX.Value     = (decimal)_cfg.NbKm.X;        NudKmY.Value     = (decimal)_cfg.NbKm.Y;        NudKmSz.Value     = (decimal)_cfg.NbKm.Hauteur;        NudKmLg.Value     = (decimal)_cfg.NbKm.Largeur;
        NudTfX.Value     = (decimal)_cfg.TotalFrais.X;  NudTfY.Value     = (decimal)_cfg.TotalFrais.Y;  NudTfSz.Value     = (decimal)_cfg.TotalFrais.Hauteur;  NudTfLg.Value     = (decimal)_cfg.TotalFrais.Largeur;

        NudRapAccX.Value = (decimal)_cfg.RapportAccueil.X;    NudRapAccY.Value = (decimal)_cfg.RapportAccueil.Y;    NudRapAccSz.Value = (decimal)_cfg.RapportAccueil.Hauteur;    NudRapAccLg.Value = (decimal)_cfg.RapportAccueil.Largeur;
        NudRapEqX.Value  = (decimal)_cfg.RapportEquipement.X; NudRapEqY.Value  = (decimal)_cfg.RapportEquipement.Y; NudRapEqSz.Value  = (decimal)_cfg.RapportEquipement.Hauteur;  NudRapEqLg.Value  = (decimal)_cfg.RapportEquipement.Largeur;

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

        _cfg.Opposant    = new FieldPos { X = (float)NudCompOppX.Value,   Y = (float)NudCompOppY.Value,   Hauteur = (float)NudCompOppHt.Value,   Largeur = (float)NudCompOppLg.Value   };
        _cfg.Date        = new FieldPos { X = (float)NudCompDateX.Value,  Y = (float)NudCompDateY.Value,  Hauteur = (float)NudCompDateHt.Value,  Largeur = (float)NudCompDateLg.Value  };
        _cfg.Heure       = new FieldPos { X = (float)NudCompHeureX.Value, Y = (float)NudCompHeureY.Value, Hauteur = (float)NudCompHeureHt.Value, Largeur = (float)NudCompHeureLg.Value };
        _cfg.Adresse     = new FieldPos { X = (float)NudCompAddrX.Value,  Y = (float)NudCompAddrY.Value,  Hauteur = (float)NudCompAddrHt.Value,  Largeur = (float)NudCompAddrLg.Value  };

        _cfg.SigX = (float)NudSigX.Value; _cfg.SigY = (float)NudSigY.Value;
        _cfg.SigW = (float)NudSigW.Value; _cfg.SigH = (float)NudSigH.Value;
        _cfg.Page               = (int)NudPage.Value;
        _cfg.RectanglesVisibles = ChkRectVisibles.Checked;
        _cfg.Save();
    }
}
