module PacmanGame

open Microsoft.Xna.Framework
open Microsoft.Xna.Framework.Graphics
open Microsoft.Xna.Framework.Input

type Entity (xVal : int , yVal : int, speed : int) =
    let mutable x = xVal
    let mutable y = yVal
    let speed = speed

    member this.X with get() = x and set v = x <- v
    member this.Y with get() = y and set v = y <- v
    member this.Speed with get() = speed

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

type NullCommand () = 
    inherit Command()

    override x.Execute() =
        ()

type Player(xVal : int, yVal : int) =
    inherit Entity ( xVal, yVal, 10)

    static member width = 50
    static member height = 50

    member this.Bounds
        with get() = new Rectangle(base.X, base.Y, 50, 50)

    override x.Update() = 
        ()



type InputHandler () = 

    member this.HandleInput(e : Entity, keyUp : Keys, keyDown : Keys, keyRight : Keys, keyLeft : Keys) : Command  = 
        let ks = Keyboard.GetState()
        if ks.IsKeyDown(keyUp)
            then MoveToCommand(e, e.X, e.Y - e.Speed) :> Command
        elif ks.IsKeyDown(keyDown)
            then MoveToCommand(e, e.X, e.Y + e.Speed) :> Command
        elif ks.IsKeyDown(keyRight)
            then MoveToCommand(e, e.X, e.Y + e.Speed) :> Command
        elif ks.IsKeyDown(keyLeft)
            then MoveToCommand(e, e.X, e.Y - e.Speed) :> Command
        else NullCommand() :> Command



type Game1 () as x = 
    inherit Game()

    do x.Content.RootDirectory <- "Content"
    let graphics = new GraphicsDeviceManager(x)

    let mutable spriteBatch = null

    let mutable MainPlayer = Player(50,50)
    let IHandler = InputHandler()

    override x.Initialize() = 
        do base.Initialize()
        let InputHandler = ()
        ()

    override x.LoadContent() =
        spriteBatch <- new SpriteBatch(x.GraphicsDevice)

    override x.Update (gameTime) =
        MainPlayer.Update()
        let cmd : Command = IHandler.HandleInput(MainPlayer :> Entity, Keys.Up, Keys.Down, Keys.Right, Keys.Left)
        ()

    override x.Draw (gameTime) =
        do x.GraphicsDevice.Clear Color.CornflowerBlue
        //spriteBatch.Draw(MainPlayer.Bounds, Color.White)
        ()


