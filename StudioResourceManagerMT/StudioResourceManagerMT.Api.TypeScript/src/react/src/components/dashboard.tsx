import * as React from 'react';
import axios from 'axios';
import { Constants } from '../constants';


interface DashboardComponentProps{
}

interface DashboardComponentState{
  connected:boolean;
  connecting:boolean;
}

export default class Dashboard extends React.Component<DashboardComponentProps, DashboardComponentState>  {
  
  state = ({connected:false, connecting:false});

  testConnection() {
    this.setState({...this.state,connecting:true});

    axios.get(Constants.ApiHealthEndpoint, {
      headers: {
        'Content-Type': 'application/json',
      },
    })
    .then(
      resp => {

        console.log(resp);
        this.setState({connecting:false, connected:true});

      },
      error => {
        console.log(error);
        this.setState({connecting:false, connected:false});
      }
    );
  }

  componentDidMount()
  {
     this.testConnection();
  }

  render() {
      let alert:JSX.Element = <div></div>;
      if(this.state.connecting){
        alert = <div>
                 <div className="alert alert-primary">Connecting...</div>
               </div>;
      }
      else if(this.state.connected){
        alert = <div>
                 <div className="alert alert-success">Connected...</div>
               </div>;
      }
      else {
        alert = <div>
                  <div className="alert alert-danger">Unable to connect to API...  <button className="btn btn-primary" onClick={(e) => this.testConnection()}>Test Connection</button></div>
                </div>;
      }

      return <div>
        {alert}
        <div>API Health Endpoint : <a target="_blank" href={Constants.ApiHealthEndpoint}>{Constants.ApiHealthEndpoint}</a></div>
        <div>Swagger Endpoint : <a target="_blank" href={Constants.SwaggerEndpoint}>{Constants.SwaggerEndpoint}</a></div>
      </div>;
  }
}