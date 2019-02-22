import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import OfficerRefCapabilityMapper from './officerRefCapabilityMapper';
import OfficerRefCapabilityViewModel from './officerRefCapabilityViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';




interface OfficerRefCapabilityDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface OfficerRefCapabilityDetailComponentState {
  model?: OfficerRefCapabilityViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class OfficerRefCapabilityDetailComponent extends React.Component<
OfficerRefCapabilityDetailComponentProps,
OfficerRefCapabilityDetailComponentState
> {
  state = {
    model: new OfficerRefCapabilityViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.OfficerRefCapabilities + '/edit/' + this.state.model!.id);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.OfficerRefCapabilities +
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
          let response = resp.data as Api.OfficerRefCapabilityClientResponseModel;

          console.log(response);

          let mapper = new OfficerRefCapabilityMapper();

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
							<h3>capabilityId</h3>
							<p>{String(this.state.model!.capabilityIdNavigation!.toDisplay())}</p>
						 </div>
					   						 <div style={{"marginBottom":"10px"}}>
							<h3>officerId</h3>
							<p>{String(this.state.model!.officerIdNavigation!.toDisplay())}</p>
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

export const WrappedOfficerRefCapabilityDetailComponent = Form.create({ name: 'OfficerRefCapability Detail' })(
  OfficerRefCapabilityDetailComponent
);

/*<Codenesium>
    <Hash>fa77808619d5b803d39359b7bcba4164</Hash>
</Codenesium>*/