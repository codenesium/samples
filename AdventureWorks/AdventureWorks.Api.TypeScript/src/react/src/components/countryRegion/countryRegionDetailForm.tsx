import React, { Component, FormEvent } from 'react';
import axios from 'axios';
import { Constants, ApiRoutes, ClientRoutes } from '../../constants';
import * as Api from '../../api/models';
import CountryRegionMapper from './countryRegionMapper';
import CountryRegionViewModel from './countryRegionViewModel';
import { Form, Input, Button, Spin, Alert } from 'antd';
import { WrappedFormUtils } from 'antd/es/form/Form';
import {StateProvinceTableComponent} from '../shared/stateProvinceTable'
	



interface CountryRegionDetailComponentProps {
  form: WrappedFormUtils;
  history: any;
  match: any;
}

interface CountryRegionDetailComponentState {
  model?: CountryRegionViewModel;
  loading: boolean;
  loaded: boolean;
  errorOccurred: boolean;
  errorMessage: string;
}

class CountryRegionDetailComponent extends React.Component<
CountryRegionDetailComponentProps,
CountryRegionDetailComponentState
> {
  state = {
    model: new CountryRegionViewModel(),
    loading: false,
    loaded: true,
    errorOccurred: false,
    errorMessage: ''
  };

  handleEditClick(e:any) {
    this.props.history.push(ClientRoutes.CountryRegions + '/edit/' + this.state.model!.countryRegionCode);
  }
  
  componentDidMount() {
    this.setState({ ...this.state, loading: true });

    axios
      .get(
        Constants.ApiEndpoint +
          ApiRoutes.CountryRegions +
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
          let response = resp.data as Api.CountryRegionClientResponseModel;

          console.log(response);

          let mapper = new CountryRegionMapper();

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
							<h3>CountryRegionCode</h3>
							<p>{String(this.state.model!.countryRegionCode)}</p>
						 </div>
					   						 <div>
							<h3>ModifiedDate</h3>
							<p>{String(this.state.model!.modifiedDate)}</p>
						 </div>
					   						 <div>
							<h3>Name</h3>
							<p>{String(this.state.model!.name)}</p>
						 </div>
					   		  </div>
          {message}
		 <div>
            <h3>StateProvinces</h3>
            <StateProvinceTableComponent 
			stateProvinceID={this.state.model!.stateProvinceID} 
			history={this.props.history} 
			match={this.props.match} 
			apiRoute={Constants.ApiEndpoint + ApiRoutes.CountryRegions + '/' + this.state.model!.countryRegionCode + '/' + ApiRoutes.StateProvinces}
			/>
         </div>
	

        </div>
      );
    } else {
      return null;
    }
  }
}

export const WrappedCountryRegionDetailComponent = Form.create({ name: 'CountryRegion Detail' })(
  CountryRegionDetailComponent
);

/*<Codenesium>
    <Hash>ac6e27dfff2e0d893512c5bfdeb5ea78</Hash>
</Codenesium>*/