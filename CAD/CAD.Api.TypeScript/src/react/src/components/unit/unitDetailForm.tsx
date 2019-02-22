import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import UnitMapper from './unitMapper';
import UnitViewModel from './unitViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {UnitOfficerTableComponent} from '../shared/unitOfficerTable'
	import {CallAssignmentTableComponent} from '../shared/callAssignmentTable'
	



interface UnitDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface UnitDetailComponentState {
  model?: UnitViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class UnitDetailComponent extends React.Component<
UnitDetailComponentProps,
UnitDetailComponentState
> {
  state = {
    model: new UnitViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.Units + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.Units +
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
          let response = resp.data as Api.UnitClientResponseModel;

          console.log(response);

          let mapper = new UnitMapper();

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
							<h3>callSign</h3>
							<p>{String(this.state.model!.callSign)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>UnitOfficers</h3>
            <UnitOfficerTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Units + '/' + this.state.model!.id + '/' + ApiRoutes.UnitOfficers}
			/>
         </div>
			 <div>
            <h3>CallAssignments</h3>
            <CallAssignmentTableComponent 
			id={this.state.model!.id} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.Units + '/' + this.state.model!.id + '/' + ApiRoutes.CallAssignments}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedUnitDetailComponent = Form.create({ name: 'Unit Detail' })(
  UnitDetailComponent
);

/*<Codenesium>
    <Hash>6a8650763af777a9904993107dfe0d76</Hash>
</Codenesium>*/