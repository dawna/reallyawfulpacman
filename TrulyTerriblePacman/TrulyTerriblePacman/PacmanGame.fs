module PacmanGame

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics

type Game1 () as x = 
    inherit Game()

    do x.Content.RootDirectory <- "Content"
    let graphics = new GraphicsDeviceManager(x)

    let mutable spriteBatch = null

    override x.Initialize() = 
        do base.Initialize()
        ()

    override x.LoadContent() =
        spriteBatch <- new SpriteBatch(x.GraphicsDevice)

    override x.Update (gameTime) =
        ()

    override x.Draw (gameTime) =
        do x.GraphicsDevice.Clear Color.CornflowerBlue
        ()