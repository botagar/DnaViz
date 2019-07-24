using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;

public class Dna {
  List<Tuple<Nucleotide, Nucleotide>> basePairs = new List<Tuple<Nucleotide, Nucleotide>>();

  SpherePrimitive sphere;

  public Dna(GraphicsDevice graphicsDevice) {
    sphere = new SpherePrimitive(graphicsDevice, 20, 10);
  }

  public void Initialize() {
    
  }

  public void Update() {}

  public void Draw() {}

  public void addBasePair(Tuple<Nucleotide,Nucleotide> basePair) {
    basePairs.Add(basePair);
  }
}