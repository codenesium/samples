import * as React from 'react';
import axios from 'axios';
import { Constants } from '../constants';
import { Alert } from 'antd'

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
        alert = <Alert message='Connecting...' type='info' />;
      }
      else if(this.state.connected){
        alert = <Alert message='Connected...' type='success' />;
      }
      else {
        alert = <Alert message='Unable to connect to API...' type='warning' />;
      }

      return <div>
        {alert}
        <br />
        <div>API Health Endpoint : <a target='_blank' href={Constants.ApiHealthEndpoint}>{Constants.ApiHealthEndpoint}</a></div>
        <div>Swagger Endpoint : <a target='_blank' href={Constants.SwaggerEndpoint}>{Constants.SwaggerEndpoint}</a></div>
      </div>;
  }
}