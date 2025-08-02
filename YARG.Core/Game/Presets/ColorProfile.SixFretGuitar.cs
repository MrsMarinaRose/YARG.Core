using System.Drawing;
using System.IO;
using YARG.Core.Extensions;
using YARG.Core.Utility;

namespace YARG.Core.Game
{
    public partial class ColorProfile
    {
        public class SixFretGuitarColors : IFretColorProvider, IBinarySerializable
        {
            #region Frets
            // here for completeness, technically GHL does not show frets on the highway
            public Color OpenFret = DefaultPurple;
            public Color GreenFret  = DefaultGreen;
            public Color RedFret    = DefaultRed;
            public Color YellowFret = DefaultYellow;
            public Color BlueFret   = DefaultBlue;
            public Color OrangeFret = DefaultOrange;

            /// <summary>
            /// Gets the fret color for a specific note index.
            /// 0 = open note, 1 = green, 5 = orange.
            /// </summary>
            public Color GetFretColor(int index)
            {
                return index switch
                {
                    0 => OpenFret,
                    1 => GreenFret,
                    2 => RedFret,
                    3 => YellowFret,
                    4 => BlueFret,
                    5 => OrangeFret,
                    _ => default
                };
            }

            public Color OpenFretInner   = DefaultPurple;
            public Color GreenFretInner  = DefaultGreen;
            public Color RedFretInner    = DefaultRed;
            public Color YellowFretInner = DefaultYellow;
            public Color BlueFretInner   = DefaultBlue;
            public Color OrangeFretInner = DefaultOrange;

            /// <summary>
            /// Gets the inner fret color for a specific note index.
            /// 0 = open note, 1 = green, 5 = orange.
            /// </summary>
            public Color GetFretInnerColor(int index)
            {
                return index switch
                {
                    0 => OpenFretInner,
                    1 => GreenFretInner,
                    2 => RedFretInner,
                    3 => YellowFretInner,
                    4 => BlueFretInner,
                    5 => OrangeFretInner,
                    _ => default
                };
            }

            public Color DarkParticles   = BlackNotes;
            public Color LightParticles  = WhiteNotes;


            /// <summary>
            /// Gets the particle color for a specific note index.
            /// 0 = open note, 1 = green, 5 = orange.
            /// </summary>
            public Color GetParticleColor(int index)
            {
                return index switch
                {
                    0 => DarkParticles,
                    1 => LightParticles,
                    2 => LightParticles,
                    3 => LightParticles,
                    4 => DarkParticles,
                    5 => DarkParticles,
                    6 => DarkParticles,
                    _ => default
                };
            }

            #endregion

            #region Notes

            public Color WhiteNote   = WhiteNotes;
            public Color BlackNote  = BlackNotes;

            /// <summary>
            /// Gets the note color for a specific note index.
            /// 0 = open note, 1 = green, 5 = orange.
            /// </summary>
            public Color GetNoteColor(int index)
            {
                return index switch
                {
                    0 => BlackNote,
                    1 => WhiteNote,
                    2 => WhiteNote,
                    3 => WhiteNote,
                    4 => BlackNote,
                    5 => BlackNote,
                    6 => BlackNote,
                    _ => default
                };
            }

            public Color OpenNoteStarPower   = DefaultStarpower;
            public Color GreenNoteStarPower  = DefaultStarpower;
            public Color RedNoteStarPower    = DefaultStarpower;
            public Color YellowNoteStarPower = DefaultStarpower;
            public Color BlueNoteStarPower   = DefaultStarpower;
            public Color OrangeNoteStarPower = DefaultStarpower;

            /// <summary>
            /// Gets the Star Power note color for a specific note index.
            /// 0 = open note, 1 = green, 5 = orange.
            /// </summary>
            public Color GetNoteStarPowerColor(int index)
            {
                return index switch
                {
                    0 => OpenNoteStarPower,
                    1 => GreenNoteStarPower,
                    2 => RedNoteStarPower,
                    3 => YellowNoteStarPower,
                    4 => BlueNoteStarPower,
                    5 => OrangeNoteStarPower,
                    6 => WhiteNote,
                    _ => default
                };
            }

            #endregion

            #region Serialization

            public SixFretGuitarColors Copy()
            {
                // Kinda yucky, but it's easier to maintain
                return (SixFretGuitarColors) MemberwiseClone();
            }

            public void Serialize(BinaryWriter writer)
            {
                writer.Write(OpenFret);
                writer.Write(GreenFret);
                writer.Write(RedFret);
                writer.Write(YellowFret);
                writer.Write(BlueFret);
                writer.Write(OrangeFret);

                writer.Write(OpenFretInner);
                writer.Write(GreenFretInner);
                writer.Write(RedFretInner);
                writer.Write(YellowFretInner);
                writer.Write(BlueFretInner);
                writer.Write(OrangeFretInner);

                writer.Write(LightParticles);
                writer.Write(DarkParticles);

                writer.Write(WhiteNote);
                writer.Write(BlackNote);

                writer.Write(OpenNoteStarPower);
                writer.Write(GreenNoteStarPower);
                writer.Write(RedNoteStarPower);
                writer.Write(YellowNoteStarPower);
                writer.Write(BlueNoteStarPower);
                writer.Write(OrangeNoteStarPower);
            }

            public void Deserialize(BinaryReader reader, int version = 0)
            {
                OpenFret = reader.ReadColor();
                GreenFret = reader.ReadColor();
                RedFret = reader.ReadColor();
                YellowFret = reader.ReadColor();
                BlueFret = reader.ReadColor();
                OrangeFret = reader.ReadColor();

                OpenFretInner = reader.ReadColor();
                GreenFretInner = reader.ReadColor();
                RedFretInner = reader.ReadColor();
                YellowFretInner = reader.ReadColor();
                BlueFretInner = reader.ReadColor();
                OrangeFretInner = reader.ReadColor();

                LightParticles = reader.ReadColor();
                DarkParticles = reader.ReadColor();

                WhiteNote = reader.ReadColor();
                BlackNote = reader.ReadColor();

                OpenNoteStarPower = reader.ReadColor();
                GreenNoteStarPower = reader.ReadColor();
                RedNoteStarPower = reader.ReadColor();
                YellowNoteStarPower = reader.ReadColor();
                BlueNoteStarPower = reader.ReadColor();
                OrangeNoteStarPower = reader.ReadColor();
            }

            #endregion
        }
    }
}