import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import DestinationMapper from './destinationMapper';
import DestinationViewModel from './destinationViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {PipelineStepDestinationTableComponent} from '../shared/pipelineStepDestinationTable'
	



interface DestinationDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface DestinationDetailComponentState {
  model?: DestinationViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class DestinationDetailComponent extends React.Component<
DestinationDetailComponentProps,
DestinationDetailComponentState
> {
  state = {
    model: new DestinationViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Destinations + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Destinations +
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
          let response = resp.data as Api.DestinationClientResponseModel;

          console.log(response);

          let mapper = new DestinationMapper();

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
									 <div style={{"marginBottom":"10px"}}>
							<h3>countryId</h3>
							<p>{String(this.state.model!.countryIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div>
							<h3>name</h3>
							<p>{String(this.state.model!.name)}</p>
						 </div>
					   						 <div>
							<h3>order</h3>
							<p>{String(this.state.model!.order)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>PipelineStepDestinations</h3>
            <PipelineStepDestinationTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Destinations + '/' + this.state.model!.id + '/' + ApiRoutes.PipelineStepDestinations}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedDestinationDetailComponent = Form.create({ name: 'Destination Detail' })(
  DestinationDetailComponent
);

/*<Codenesium>
    <Hash>670b769fb9547328af8edd0c212133b8</Hash>
</Codenesium>*/