import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import AirTransportMapper from './airTransportMapper';
import AirTransportViewModel from './airTransportViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface AirTransportDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface AirTransportDetailComponentState {
  model?: AirTransportViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class AirTransportDetailComponent extends React.Component<
AirTransportDetailComponentProps,
AirTransportDetailComponentState
> {
  state = {
    model: new AirTransportViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.AirTransports + '/edit/' + this.state.model!.airlineId);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.AirTransports +
          '/' +
          this.props.match.params.id,
        {
          headers: {
            'Content-Type': 'application/json',
          },
        }
      )
      .then(
        resp => {
          let response = resp.data as Api.AirTransportClientResponseModel;

          console.log(response);

          let mapper = new AirTransportMapper();

          this.setState({
            model: mapper.mapApiResponseToViewModel(response),
            loading: false,
            loaded: true,
            errorOccurred: false,
            errorMessage: '',
          });
        },
        error => {
          console.log(error);
          this.setState({
            model: undefined,
            loading: false,
            loaded: true,
            errorOccurred: true,
            errorMessage: 'Error from API',
          });
        }
      );
  }

  render() {
    
    let message: JSX.Element = <div />;
    if (this.state.errorOccurred) {
      message = <Alert message={this.state.errorMessage} type="error" />;
    } 
  
    if (this.state.loading) {
      return <Spin size="large" />;
    } else if (this.state.loaded) {
      return (
        <div>
		<Button 
			style={{'float':'right'}}
			type="primary" 
			onClick={(e:any) => {
				this.handleEditClick(e)
				}}
			>
             <i className="fas fa-edit" />
		  </Button>
		  <div>
									 <div>
							<h3>airlineId</h3>
							<p>{String(this.state.model!.airlineId)}</p>
						 </div>
					   						 <div>
							<h3>flightNumber</h3>
							<p>{String(this.state.model!.flightNumber)}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>handlerId</h3>
							<p>{String(this.state.model!.handlerIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>id</h3>
							<p>{String(this.state.model!.id)}</p>
						 </div>
					   						 <div>
							<h3>landDate</h3>
							<p>{String(this.state.model!.landDate)}</p>
						 </div>
					   						 <div>
							<h3>pipelineStepId</h3>
							<p>{String(this.state.model!.pipelineStepId)}</p>
						 </div>
					   						 <div>
							<h3>takeoffDate</h3>
							<p>{String(this.state.model!.takeoffDate)}</p>
						 </div>
					   		  </div>
          {message}


        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedAirTransportDetailComponent = Form.create({ name: 'AirTransport Detail' })(
  AirTransportDetailComponent
);

/*<Codenesium>
    <Hash>da2a9872973d7da9a73821b7d876c23d</Hash>
</Codenesium>*/