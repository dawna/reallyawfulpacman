module PacmanGame

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type Game1 () as x = 
    inherit Game()

    do x.Content.RootDirectory <- "Content"
    let graphics = new GraphicsDeviceManager(x)
    let mutable spriteBatch = new SpriteBatch (x.GraphicsDevice)

    override x.Initialize() = 
        //do spriteBatch
        do base.Initialize()
        ()

    override x.LoadContent() =
        ()

    override x.Update (gameTime) =
        ()

    override x.Draw (gameTime) =
        do x.GraphicsDevice.Clear Color.CornflowerBlue
        ()