module PacmanGame

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

type Entity (xVal : int , yVal : int, speed : int) =
    let mutable x = xVal
    let mutable y = yVal

    member this.X with get() = x and set v = x <- v
    member this.Y with get() = y and set v = y <- v

    abstract Update : unit -> unit
    default this.Update() = ()

type Command() = 
    abstract Execute : unit -> unit
    default this.Execute() = ()

let MoveTo (e : Entity, xVal : int, yVal : int) =
     e.X <- xVal
     e.Y <- yVal
     ()

type MoveToCommand (e : Entity, xVal : int, yVal : int) = 
    inherit Command()

    override x.Execute() =
        MoveTo(e, xVal, yVal)
        ()

type Player(xVal : int, yVal : int) =
    inherit Entity ( xVal, yVal, 10)

    static member width = 50
    static member height = 50

//    member this.Move(keyUp : Keys) (keyDown : Keys) (keyRight : Keys) (keyLeft : Keys)= 
//        let ks = Keyboard.GetState()
//        if ks.IsKeyDown(keyUp)
//            then y <- y - speed
//        else if ks.IsKeyDown(keyDown)
//            then y <- y + speed
//        else if ks.IsKeyDown(keyRight)
//            then x <- x + speed
//        else if ks.IsKeyDown(keyLeft)
//            then x <- x - speed

    override x.Update() = 
        ()


 
let MainPlayer = Player(50, 50)  

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
        MainPlayer.Update()
        ()

    override x.Draw (gameTime) =
        do x.GraphicsDevice.Clear Color.CornflowerBlue
        ()


